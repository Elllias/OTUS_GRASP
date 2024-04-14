using AI.Blackboards;
using AI.GOAP;
using Elementary;
using Entities;
using Game.GameEngine.Entities;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HarvestFactInspector : FactInspector, IBlackboardInjective
    {
        public IBlackboard Blackboard { private get; set; }

        [SerializeField]
        private ScriptableFloat minDistance;

        [Header("Blackboard")]
        [BlackboardKey]
        [SerializeField]
        private string unitKey;

        [BlackboardKey]
        [SerializeField]
        private string resourceKey;

        [Header("World State")]
        [FactKey]
        [SerializeField]
        private string atResource;
        
        public override void PopulateFacts(FactState state)
        {
            if (this.Blackboard.TryGetVariable(this.unitKey, out IEntity unit) &&
                this.Blackboard.TryGetVariable(this.resourceKey, out IEntity resource))
            {
                var distance = EntityUtils.Distance(resource, unit);
                var atResource = distance <= this.minDistance.Current;
                state.SetFact(this.atResource, atResource);
            }
        }
    }
}