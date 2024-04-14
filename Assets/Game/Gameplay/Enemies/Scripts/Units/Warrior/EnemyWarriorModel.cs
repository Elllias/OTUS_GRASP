using System;
using System.Collections.Generic;
using System.Linq;
using Elementary;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Animation;
using Game.GameEngine.Mechanics;
using JetBrains.Annotations;
using Declarative;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Gameplay.Enemies
{
    public sealed class EnemyWarriorModel : DeclarativeModel
    {
        [Section]
        [SerializeField]
        private ScriptableEnemyWarrior config;

        [Section]
        [SerializeField, Space]
        public Core core = new();

        [Section]
        [SerializeField]
        private Components components = new();

        [Section]
        [SerializeField]
        private States states = new();

        [Section]
        [SerializeField]
        public Animations animations = new();

        [Section]
        [SerializeField]
        private new Audio audio = new();

        [Section]
        [SerializeField]
        private Canvas canvas = new();

        [Serializable]
        public sealed class Core
        {
            [SerializeField]
            public TransformEngine transformEngine = new();

            [SerializeField]
            public BoolVariable isEnable = new();

            [Section]
            [SerializeField]
            public Move move = new();

            [Section]
            [SerializeField]
            public Collision collision = new();

            [Section]
            [SerializeField]
            public Life life = new();

            [Section]
            [SerializeField]
            public Combat combat = new();

            [Serializable]
            public sealed class Move
            {
                public readonly MoveInDirectionMotor motor = new();

                public readonly FixedUpdateMechanics fixedUpdateMechanics = new();

                [Construct]
                private void Construct(Core core)
                {
                    this.fixedUpdateMechanics.Construct(_ =>
                        {
                            if (core.isEnable.Current) this.motor.Update();
                        }
                    );
                }
            }

            [Serializable]
            public sealed class Collision
            {
                [SerializeField]
                private GameObject collisionLayer;

                [SerializeField]
                private Collider[] colliders;

                private readonly BoolMechanics enableMechanics = new();

                [Construct]
                private void Construct(Core core)
                {
                    this.enableMechanics.Construct(core.isEnable, this.collisionLayer.SetActive);
                    core.life.hitPoints.AddCurrentListener(hitPoints =>
                    {
                        var isActive = hitPoints > 0;
                        this.colliders.ForEach(it => it.enabled = isActive);
                    });
                }
            }

            [Serializable]
            public sealed class Life
            {
                [SerializeField]
                public TakeDamageEngine takeDamageEngine = new();

                [SerializeField]
                public HitPoints hitPoints = new();

                [SerializeField]
                public Emitter<DestroyArgs> destroyEmitter = new();

                [SerializeField]
                public Emitter respawnEmitter = new();

                [Construct]
                private void ConstructTakeDamage()
                {
                    this.takeDamageEngine.Construct(this.hitPoints, this.destroyEmitter);
                }

                [Construct]
                private void ConstructDeath(Combat combat, Move move)
                {
                    this.destroyEmitter.AddListener(_ => combat.combatOperator.Stop());
                    this.destroyEmitter.AddListener(_ => move.motor.Interrupt());
                }

                [Construct]
                private void ConstructRespawn(Combat combat)
                {
                    this.respawnEmitter.AddListener(() => this.hitPoints.RestoreToFull());
                }

                [Construct]
                private void InitHitPoints(ScriptableEnemyWarrior config)
                {
                    var hitPoints = config.hitPoints;
                    this.hitPoints.Setup(hitPoints, hitPoints);
                }
            }

            [Serializable]
            public sealed class Combat
            {
                [SerializeField]
                public Operator<CombatOperation> combatOperator = new();

                private CombatAction_DealDamageIfAlive damageAction = new();

                [Construct]
                private void ConstructCombat(ScriptableEnemyWarrior config, Core core)
                {
                    this.combatOperator.AddConditions(
                        new CombatCondition_CheckDistance(
                            core.transformEngine, config.minCombatDistance
                        ),
                        new CombatCondition_CheckEntity(
                            config.combatConditions.ToArray<IEntityCondition>()
                        ),
                        new ConditionDelegate<CombatOperation>(
                            _ => !core.move.motor.IsMoving
                        )
                    );

                    this.combatOperator.AddStartActions(
                        new CombatAction_LookAtTarget(core.transformEngine)
                    );
                }

                [Construct]
                private void ConstructDamageAction(GameObject attacker, ScriptableEnemyWarrior config)
                {
                    this.damageAction.attacker = attacker;
                    this.damageAction.damage = new Value<int>(config.damage);
                }

                public void DealDamage()
                {
                    if (this.combatOperator.IsActive)
                    {
                        this.damageAction.Do(this.combatOperator.Current);
                    }
                }
            }
        }

        [Serializable]
        private sealed class Components
        {
            [SerializeField]
            public MonoEntityStd entity;

            [SerializeField]
            private Transform movingPivot;

            [Construct]
            private void Construct(ScriptableEnemyWarrior config, Core core)
            {
                this.entity.AddRange(
                    new Component_GetName(new Value<string>(config.enemyName)),
                    new Component_ObjectType(config.objectType),
                    new Component_GetPivot(this.movingPivot)
                );

                this.entity.AddRange(
                    new Component_TransformEngine(core.transformEngine),
                    new Component_Enable(core.isEnable),
                    new Component_MoveInDirection(core.move.motor),
                    new Component_MeleeCombat(core.combat.combatOperator),
                    new Component_Respawn(core.life.respawnEmitter),
                    new Component_HitPoints(core.life.hitPoints),
                    new Component_TakeDamage(core.life.takeDamageEngine),
                    new Component_Destroy_Emitter<DestroyArgs>(core.life.destroyEmitter),
                    new Component_IsAlive_HitPoints(core.life.hitPoints),
                    new Component_IsDestroyed_HitPoints(core.life.hitPoints)
                );
            }
        }

        [Serializable]
        private sealed class States
        {
            [ShowInInspector, ReadOnly]
            public StateMachineAuto<string> stateMachine = new();

            [Section]
            public IdleState idleState = new();

            [Section]
            public MoveState moveState = new();

            [Section]
            public CombatState combatState = new();

            [Section]
            public DeathState deathState = new();

            private readonly BoolMechanics enableMechanics = new();

            private readonly FixedUpdateMechanics updateMechanics = new();

            [Construct]
            private void ConstructStateMachine(Core core)
            {
                this.stateMachine.states = new List<StateEntry<string>>
                {
                    new(nameof(IdleState), this.idleState),
                    new(nameof(MoveState), this.moveState),
                    new(nameof(CombatState), this.combatState),
                    new(nameof(DeathState), this.deathState)
                };

                this.stateMachine.orderedTransitions = new List<StateTransition<string>>
                {
                    new(nameof(DeathState), () => core.life.hitPoints.IsOver()),
                    new(nameof(MoveState), () => core.move.motor.IsMoving),
                    new(nameof(CombatState), () => core.combat.combatOperator.IsActive),
                    new(nameof(IdleState), () => true)
                };
            }

            [Construct]
            private void ConstructMechanics(Core core)
            {
                this.enableMechanics.Construct(core.isEnable, isEnable =>
                {
                    if (isEnable)
                        this.stateMachine.Enter();
                    else
                        this.stateMachine.Exit();
                });

                this.updateMechanics.Construct(_ =>
                {
                    if (core.isEnable.Current)
                    {
                        this.stateMachine.Update();
                    }
                });
            }

            public sealed class IdleState : StateComposite
            {
            }

            public sealed class MoveState : StateComposite
            {
                private readonly MoveInDirectionState_Position positionState = new();

                private readonly MoveInDirectionState_Rotation rotationState = new();

                [Construct]
                private void ConstructSelf()
                {
                    this.states = new List<IState>
                    {
                        this.positionState,
                        this.rotationState
                    };
                }

                [Construct]
                private void ConstructStates(Core core, ScriptableEnemyWarrior config)
                {
                    var moveMotor = core.move.motor;
                    var transform = core.transformEngine;
                    var moveSpeed = new Value<float>(config.moveSpeed);

                    this.positionState.ConstructMotor(moveMotor);
                    this.positionState.ConstructTransform(transform);
                    this.positionState.ConstructSpeed(moveSpeed);

                    this.rotationState.mode = MoveInDirectionState_Rotation.Mode.SMOOTH;
                    this.rotationState.rotationSpeed = 45.0f;
                    this.rotationState.ConstructMotor(moveMotor);
                    this.rotationState.ConstructTransform(transform);
                }
            }

            public sealed class CombatState : StateComposite
            {
                private readonly CombatState_ControlTargetDestroy controlDestroyState = new();

                private readonly CombatState_ControlTargetDistance controlDistanceState = new();

                private readonly CombatState_UpdateRotation updateRotationState = new();

                [Construct]
                private void ConstructSelf()
                {
                    this.states = new List<IState>
                    {
                        this.controlDestroyState,
                        this.controlDistanceState,
                        this.updateRotationState
                    };
                }

                [Construct]
                private void Construct(GameObject attacker, Core core, ScriptableEnemyWarrior configModule)
                {
                    var combatOperator = core.combat.combatOperator;
                    var transform = core.transformEngine;

                    //Constrol destroy state:
                    this.controlDestroyState.ConstructOperator(combatOperator);
                    this.controlDestroyState.ConstructAttacker(attacker);

                    //Check distance state:
                    this.controlDistanceState.ConstructOperator(combatOperator);
                    this.controlDistanceState.ConstructTransform(transform);
                    this.controlDistanceState.ConstructMinDistance(configModule.minCombatDistance);

                    //Control rotation:
                    this.updateRotationState.ConstructOperator(combatOperator);
                    this.updateRotationState.ConstructTransform(transform);
                    this.updateRotationState.mode = CombatState_UpdateRotation.Mode.SMOOTH;
                    this.updateRotationState.rotationSpeed = 45.0f;
                }
            }

            public sealed class DeathState : StateComposite
            {
            }
        }

        [Serializable]
        public sealed class Animations
        {
            [SerializeField]
            public Animator animator;

            [SerializeField]
            public AnimatorObservable observable;

            [Space, ShowInInspector, ReadOnly]
            public AnimatorMachine animatorMachine = new();

            [Section]
            private Common commonStates = new();

            [Section]
            private IdleState idleState = new();

            [Section]
            private MoveState moveState = new();

            [Section]
            private CombatState combatState = new();

            [Section]
            private DeathState deathState = new();

            [Construct]
            private void Construct(States states)
            {
                const int IDLE = 0;
                const int MOVE = 1;
                const int COMBAT = 3;
                const int DEATH = 5;

                this.animatorMachine.Construct(this.animator, this.observable);

                this.animatorMachine.states = new List<AnimatorMachine.StateEntry>
                {
                    new(IDLE, this.idleState),
                    new(MOVE, this.moveState),
                    new(COMBAT, this.combatState),
                    new(DEATH, this.deathState)
                };

                var fsm = states.stateMachine;
                this.animatorMachine.orderedTransitions = new List<AnimatorMachine.StateTransition>
                {
                    new(IDLE, () => fsm.CurrentState == nameof(States.IdleState)),
                    new(MOVE, () => fsm.CurrentState == nameof(States.MoveState)),
                    new(COMBAT, () => fsm.CurrentState == nameof(States.CombatState)),
                    new(DEATH, () => fsm.CurrentState == nameof(States.DeathState))
                };
            }

            public sealed class Common
            {
                public readonly AnimatorState_ApplyRootMotion applyRootMotionState = new();

                public readonly AnimatorState_ResetRootMotion resetRootMotionState = new();

                [Construct]
                private void Construct(Animations animations)
                {
                    this.applyRootMotionState.ConstructMachine(animations.animatorMachine);
                    this.resetRootMotionState.ConstructMachine(animations.animatorMachine);
                }
            }

            public sealed class IdleState : StateComposite
            {
                [Construct]
                private void Construct(Common common)
                {
                    this.states = new List<IState>
                    {
                        common.resetRootMotionState
                    };
                }
            }

            public sealed class MoveState : StateComposite
            {
                [Construct]
                private void ConstructSelf(Common common)
                {
                    this.states = new List<IState>
                    {
                        common.resetRootMotionState
                    };
                }
            }

            public sealed class CombatState : StateComposite
            {
                private readonly AnimatorState_ListenEvent dealDamageListener = new();

                [Construct]
                private void ConstructSelf(Common common)
                {
                    this.states = new List<IState>
                    {
                        common.resetRootMotionState,
                        this.dealDamageListener
                    };
                }

                [Construct]
                private void ConstructDealDamageListener(Animations animations, Core core)
                {
                    this.dealDamageListener.ConstructAnimMachine(animations.animatorMachine);
                    this.dealDamageListener.ConstructAnimEvents("attack");
                    this.dealDamageListener.ConstructAction(core.combat.DealDamage);
                }
            }

            [Serializable]
            public sealed class DeathState : StateComposite
            {
                [Construct]
                private void ConstructSelf(Common common)
                {
                    this.states = new List<IState>
                    {
                        common.applyRootMotionState
                    };
                }
            }
        }

        [Serializable]
        public sealed class Audio
        {
            [SerializeField]
            private AudioSource audioSource;

            [SerializeField]
            private SoundCatalog soundCatalog;

            [SerializeField]
            private string deathSFX;

            private SoundEmitter soundEmitter;

            [Construct]
            private void ConstructEmiiter()
            {
                this.soundEmitter = new SoundEmitter(this.audioSource, this.soundCatalog);
            }

            [Construct]
            private void ConstructSounds(Core core)
            {
                core.life.destroyEmitter.AddListener(_ => this.soundEmitter.PlaySound(this.deathSFX));
            }
        }

        [Serializable]
        public sealed class Canvas
        {
            [SerializeField]
            private HitPointsBar hitPointsView;
            
            private readonly HitPointsBarAdapterV1 hitPointsViewAdapter = new();

            [Construct]
            private void Construct(Core core)
            {
                this.hitPointsViewAdapter.Construct(core.life.hitPoints, this.hitPointsView);
            }
        }
    }
}