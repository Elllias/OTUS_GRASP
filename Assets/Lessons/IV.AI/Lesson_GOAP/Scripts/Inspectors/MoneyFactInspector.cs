using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class MoneyFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private int requiredMoney = 100;

        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [Header("World State")]
        [FactKey]
        [SerializeField]
        private string moneyEnough;

        public override void PopulateFacts(FactState state)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                state.SetFact(this.moneyEnough, this.MoneyEnough(unit));
            }
        }

        private bool MoneyEnough(IEntity unit)
        {
            return unit.Get<IComponent_GetMoney>().Money >= this.requiredMoney;
        }
    }
}