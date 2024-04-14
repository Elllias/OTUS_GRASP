using AI.Blackboards;
using AI.GOAP;
using Entities;
using Game.GameEngine.GameResources;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class ResourceFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }
        
        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [Header("World State")]
        [FactKey]
        [SerializeField]
        private string resourceExists;

        public override void PopulateFacts(FactState state)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                state.SetFact(this.resourceExists, this.ResourceExists(unit));
            }
        }

        private bool ResourceExists(IEntity unit)
        {
            return unit.Get<IComponent_ResourceSource>().GetSum() > 0;
        }
    }
}