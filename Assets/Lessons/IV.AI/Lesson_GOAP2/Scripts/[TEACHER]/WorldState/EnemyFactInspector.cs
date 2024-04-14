using AI.GOAP;
using Entities;
using Game.GameEngine.Entities;
using Lessons.AI.HierarchicalStateMachine;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    public sealed class EnemyFactInspector : FactInspector
    {
        [SerializeField]
        private Blackboard blackboard;

        [Space]
        [SerializeField, FactKey]
        private string hasEnemy;

        [SerializeField, FactKey]
        private string nearEnemy;

        [SerializeField, FactKey]
        private string atEnemy;

        public override void PopulateFacts(FactState state)
        {
            if (this.blackboard.TryGetVariable(BlackboardKeys.UNIT, out IEntity unit) &&
                this.blackboard.TryGetVariable(BlackboardKeys.ENEMY, out IEntity enemy) &&
                this.blackboard.TryGetVariable(BlackboardKeys.NEAR_ENEMY_DISTANCE, out float nearDistance) &&
                this.blackboard.TryGetVariable(BlackboardKeys.AT_ENEMY_DISTANCE, out float atDistance))
            {
                var currentDistance = EntityUtils.Distance(unit, enemy);

                state.SetFact(this.hasEnemy, true);
                state.SetFact(this.nearEnemy, currentDistance <= nearDistance);
                state.SetFact(this.atEnemy, currentDistance <= atDistance);
            }
        }
    }
}