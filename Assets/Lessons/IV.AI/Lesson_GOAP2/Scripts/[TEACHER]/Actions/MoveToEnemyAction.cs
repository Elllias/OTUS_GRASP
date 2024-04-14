using System.Collections;
using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Entities;
using Game.GameEngine.Mechanics;
using Lessons.AI.Architecture;
using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;
using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class MoveToEnemyAction : Actor
    {
        [SerializeField]
        private Blackboard blackboard;

        [SerializeField]
        private MoveToPositionAgent moveToPositionAgent;

        [Space]
        [SerializeField, BlackboardKey]
        private string stoppingDistanceKey;

        private Coroutine coroutine;
        
        public override bool IsValid()
        {
            return this.blackboard.HasVariable(BlackboardKeys.UNIT) &&
                   this.blackboard.HasVariable(BlackboardKeys.ENEMY);
        }

        public override int EvaluateCost()
        {
            var unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            var enemy = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);
            var stoppingDistance = this.blackboard.GetVariable<float>(this.stoppingDistanceKey);
            
            var distance = Mathf.Max(EntityUtils.Distance(unit, enemy) - stoppingDistance, 0);
            return Mathf.RoundToInt(distance);
        }

        protected override void Play()
        {
            var unit = this.blackboard.GetVariable<IEntity>(BlackboardKeys.UNIT);
            var stoppingDistance = this.blackboard.GetVariable<float>(this.stoppingDistanceKey);
            
            var enemy = this.blackboard.GetVariable<IEntity>(BlackboardKeys.ENEMY);
            var enemyTransform = enemy.Get<IComponent_GetPosition>();
            
            this.moveToPositionAgent.SetUnit(unit);
            this.moveToPositionAgent.SetStoppingDistance(stoppingDistance);
            this.moveToPositionAgent.SetTargetPosiiton(enemyTransform.Position);
            this.moveToPositionAgent.Play();

            this.coroutine = this.StartCoroutine(this.UpdateEnemyPosition(enemyTransform));
        }

        private IEnumerator UpdateEnemyPosition(IComponent_GetPosition enemyTransform)
        {
            while (!this.moveToPositionAgent.IsReached)
            {
                this.moveToPositionAgent.SetTargetPosiiton(enemyTransform.Position);
                yield return new WaitForFixedUpdate();
            }
            
            this.Return(true);
        }

        protected override void OnDispose()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
            
            this.moveToPositionAgent.Stop();
        }
    }
}