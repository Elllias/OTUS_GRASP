using System;
using System.Collections.Generic;
using AI.Blackboards;
using AI.BTree;
using AI.Iterators;
using AI.Waypoints;
using Elementary;
using Entities;
using Game.GameEngine.AI;
using Game.GameEngine.Mechanics;
using GameSystem;
using Declarative;
using Polygons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public sealed class EnemyWarriorAI : DeclarativeModel, IGameConstructElement
    {
        [Section]
        [SerializeField]
        private ScriptableEnemyWarriorAI config;

        [Section]
        [SerializeField]
        private Core core = new();

        [Section]
        [SerializeField]
        private Components components = new();

        [Section]
        [ShowInInspector, ReadOnly]
        private Behaviour behaviour = new();

        [SerializeField]
        private External external;

        [Serializable]
        public sealed class Core
        {
            [SerializeField]
            public BoolVariable isEnable = new();

            [ShowInInspector, ReadOnly]
            public Blackboard blackboard = new();

            [Space]
            [SerializeField]
            public ColliderDetectionOverlapSphere sensor;

            private readonly BoolMechanics enableMechanics = new();

            [Construct]
            private void ConstructEnable()
            {
                this.enableMechanics.Construct(this.isEnable, isEnable =>
                {
                    if (isEnable)
                        this.sensor.Play();
                    else
                        this.sensor.Stop();
                });
            }

            [Construct]
            private void ConstructSensor(ScriptableEnemyWarriorAI config)
            {
                var opponentDetector = new EnemyOpponentDetector(
                    this.blackboard,
                    ScriptableEnemyWarriorAI.TARGET_KEY,
                    config.detectTargetConditions
                );
                this.sensor.AddListener(opponentDetector);
            }
        }

        [Serializable]
        private sealed class Components
        {
            [SerializeField]
            private MonoEntityStd ai;

            [Construct]
            private void Construct(Core core)
            {
                this.ai.Add(new Component_Enable(core.isEnable));
                this.ai.Add(new Component_Blackboard(core.blackboard));
            }
        }

        private sealed class Behaviour
        {
            private readonly BehaviourTree behaviourTree = new();

            [Section]
            [ShowInInspector, ReadOnly]
            private AttackBranch attackBranch = new();

            [Section]
            [ShowInInspector, ReadOnly]
            private PatrolBranch patrolBranch = new();

            private readonly BehaviourTreeAborter_ByBlackboard treeAborter = new();

            private readonly UpdateMechanics updateMechanics = new();

            [Construct]
            private void ConstructTree()
            {
                this.behaviourTree.root = new BehaviourNodeSelector(
                    this.attackBranch,
                    this.patrolBranch
                );
            }

            [Construct]
            private void ConstructUpdateMechanics(Core core)
            {
                this.updateMechanics.Construct(_ =>
                {
                    if (core.isEnable.Current)
                    {
                        this.behaviourTree.Run(null);
                    }
                    else
                    {
                        this.behaviourTree.Abort();
                    }
                });
            }

            [Construct]
            private void ConstructAbort(Core core)
            {
                this.treeAborter.tree = this.behaviourTree;
                this.treeAborter.blackboard = core.blackboard;
                this.treeAborter.blackboardKeys = new List<string>
                {
                    ScriptableEnemyWarriorAI.TARGET_KEY
                };
            }

            public sealed class AttackBranch : BehaviourNodeSequence
            {
                [ShowInInspector, ReadOnly]
                private BehaviourNodeCondition conditionNode = new();

                [ShowInInspector, ReadOnly]
                private BTNode_Entity_FollowEntityByPolygon followNode = new();

                [ShowInInspector, ReadOnly]
                private BehaviourNode_WaitForSeconds waitForSeconds = new();

                [ShowInInspector, ReadOnly]
                private BTNode_Entity_MeleeCombat combatNode = new();

                [Construct]
                private void ConstructSelf()
                {
                    this.children = new IBehaviourNode[]
                    {
                        this.conditionNode,
                        this.followNode,
                        this.waitForSeconds,
                        new BehaviourNodeDecorator(this.combatNode, success: true)
                    };
                }

                [Construct]
                private void ConstructConditionNode(Core core)
                {
                    this.conditionNode.condition = new BTCondition_HasBlackboardVariable(
                        core.blackboard, ScriptableEnemyWarriorAI.TARGET_KEY
                    );
                }

                [Construct]
                private void ConstructFollowNode(ScriptableEnemyWarriorAI config, MonoBehaviour monoContext, Core core)
                {
                    this.followNode.ConstructBlackboard(core.blackboard);
                    this.followNode.ConstructBlackboardKeys(
                        ScriptableEnemyWarriorAI.UNIT_KEY,
                        ScriptableEnemyWarriorAI.TARGET_KEY,
                        ScriptableEnemyWarriorAI.SURFACE_KEY
                    );
                    this.followNode.ConstructIntermediateDistance(config.pointStoppingDistance);
                    this.followNode.ConstructStoppingDistance(config.meleeStoppingDistance);
                }

                [Construct]
                private void ConstructWaitNode(MonoBehaviour monoContext)
                {
                    this.waitForSeconds.waitSeconds = 0.1f;
                }

                [Construct]
                private void ConstructCombatNode(Core core)
                {
                    this.combatNode.ConstructBlackboard(core.blackboard);
                    this.combatNode.ConstructBlackboardKeys(
                        ScriptableEnemyWarriorAI.UNIT_KEY,
                        ScriptableEnemyWarriorAI.TARGET_KEY
                    );
                }
            }

            public sealed class PatrolBranch : BehaviourNodeSequence
            {
                [ShowInInspector, ReadOnly]
                private readonly BTNode_Iterator_AssignPosition assignPositionNode = new();

                [ShowInInspector, ReadOnly]
                private readonly BTNode_Iterator_MoveNext moveNextPointNode = new();

                [ShowInInspector, ReadOnly]
                private readonly BTNode_Entity_MoveToPosition moveToPositionNode = new();

                [ShowInInspector, ReadOnly]
                private readonly BehaviourNode_WaitForSeconds waitNode = new();

                [Construct]
                private void ConstructSelf()
                {
                    this.children = new IBehaviourNode[]
                    {
                        this.assignPositionNode,
                        this.moveNextPointNode,
                        this.moveToPositionNode,
                        this.waitNode
                    };
                }

                [Construct]
                private void ConstructAssignPositionNode(Core core)
                {
                    this.assignPositionNode.ConstructBlackboard(core.blackboard);
                    this.assignPositionNode.ConstructBlackboardKeys(
                        ScriptableEnemyWarriorAI.WAYPOINTS_KEY,
                        ScriptableEnemyWarriorAI.TARGET_POSITION_KEY
                    );
                }

                [Construct]
                private void ConstructMoveNextNode(Core core)
                {
                    this.moveNextPointNode.ConstructBlackboard(core.blackboard);
                    this.moveNextPointNode.ConstructBlackboardKeys(ScriptableEnemyWarriorAI.WAYPOINTS_KEY);
                }

                [Construct]
                private void ConstructMoveToPositionNode(Core core, ScriptableEnemyWarriorAI config)
                {
                    this.moveToPositionNode.ConstructBlackboard(core.blackboard);
                    this.moveToPositionNode.ConstructBlackboardKeys(
                        ScriptableEnemyWarriorAI.UNIT_KEY,
                        ScriptableEnemyWarriorAI.TARGET_POSITION_KEY
                    );
                    this.moveToPositionNode.ConstructStoppingDistance(config.pointStoppingDistance);
                }

                [Construct]
                private void ConstructWaitNode(ScriptableEnemyWarriorAI config)
                {
                    this.waitNode.waitSeconds = config.patrolWaitTime;
                }
            }
        }

        [Serializable]
        public sealed class External
        {
            [SerializeField]
            public MonoEntity unit;

            [Space]
            [SerializeField]
            public WaypointsPath waypointsPath;

            [SerializeField]
            public IteratorMode waypointMode = IteratorMode.CIRCLE;

            [Space]
            [SerializeField]
            public string surfacePolygonName = "WoodPolygon";

            // ReSharper disable once UnusedParameter.Global
            public void ConstructGame(EnemyWarriorAI ai, GameContext context)
            {
                var blackboard = ai.core.blackboard;
                var sensor = ai.core.sensor;

                //Set Unit:
                blackboard.AddVariable(ScriptableEnemyWarriorAI.UNIT_KEY, this.unit);

                //Set Waypoints:
                var waypoints = this.waypointsPath.GetPositionPoints().ToArray();
                var iterator = IteratorFactory.CreateIterator(this.waypointMode, waypoints);
                blackboard.AddVariable(ScriptableEnemyWarriorAI.WAYPOINTS_KEY, iterator);

                //Set surface:
                var polygon = GameObject.Find(this.surfacePolygonName).GetComponent<MonoPolygon>();
                blackboard.AddVariable(ScriptableEnemyWarriorAI.SURFACE_KEY, polygon);

                //Set center point:
                var centerPoint = this.unit.Get<IComponent_GetPivot>().Pivot;
                sensor.SetCenterPoint(centerPoint);
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.external.ConstructGame(this, context);
        }
    }
}