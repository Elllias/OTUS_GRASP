using System.Collections;
using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [AddComponentMenu(BehaviourTreePaths.MENU_PATH + "BTNode «Inspect Target Distance»")]
    public sealed class UBTNode_InspectTargetDistance : UnityBehaviourNode_Coroutine, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [Space]
        [SerializeField]
        private FloatAdapter observePeriod; //0.2f;

        [SerializeField]
        private FloatAdapter visibleDistance; // 3.0f;

        private IComponent_GetPosition unitComponent;

        private IComponent_GetPosition enemyComponent;

        protected override IEnumerator RunRoutine()
        {
            if (!this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                yield break;
            }

            if (!this.Blackboard.TryGetVariable(this.targetKey, out IEntity enemy)) 
            {
                this.Return(false);
                yield break;
            }
            
            this.unitComponent = unit.Get<IComponent_GetPosition>();
            this.enemyComponent = enemy.Get<IComponent_GetPosition>();

            yield return this.HandleDistance();
        }

        private IEnumerator HandleDistance()
        {
            var period = new WaitForSeconds(this.observePeriod.Current);
            while (true)
            {
                yield return period;
                if (!this.IsDistanceReached())
                {
                    this.Return(false);
                    yield break;
                }
            }
        }
        
        private bool IsDistanceReached()
        {
            var unitPosition = this.unitComponent.Position;
            var targetPosition = this.enemyComponent.Position;

            var distanceVector = targetPosition - unitPosition;
            return distanceVector.sqrMagnitude <= Mathf.Pow(this.visibleDistance.Current, 2);
        }
    }
}