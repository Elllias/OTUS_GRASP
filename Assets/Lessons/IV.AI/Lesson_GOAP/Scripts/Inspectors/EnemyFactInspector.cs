using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class EnemyFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [Space]
        [SerializeField]
        private FloatAdapter meleeDistance;

        [SerializeField]
        private FloatAdapter rangeDistance;
        
        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string targetKey;

        [Header("World State")]
        [FactKey]
        [SerializeField]
        private string enemyAlive;

        [FactKey]
        [SerializeField]
        private string nearEnemy;

        [FactKey]
        [SerializeField]
        private string atEnemy;
        
        public override void PopulateFacts(FactState state)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit) &&
                this.Blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                var distance = EntityUtils.Distance(unit, target);
            
                state.SetFact(this.enemyAlive, target.Get<IComponent_IsAlive>().IsAlive);
                state.SetFact(this.nearEnemy, distance <= this.rangeDistance.Current);
                state.SetFact(this.atEnemy, distance <= this.meleeDistance.Current);
            }
        }
    }
}