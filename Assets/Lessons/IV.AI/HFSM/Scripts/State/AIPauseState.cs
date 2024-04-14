using UnityEngine;
using static Lessons.AI.HierarchicalStateMachine.BlackboardKeys;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class AIPauseState : AIState
    {
        [SerializeField]
        private Blackboard blackboard;
        
        public override void OnUpdate()
        {
            if (!this.blackboard.HasVariable(CURRENT_TIME))
            {
                return;
            }
            
            var currentTime = this.blackboard.GetVariable<float>(CURRENT_TIME);
            if (currentTime > 0)
            {
                this.blackboard.SetVariable(CURRENT_TIME, currentTime - Time.fixedDeltaTime);
            }
            else
            {
                this.blackboard.RemoveVariable(CURRENT_TIME);
            }
        }
    }
}