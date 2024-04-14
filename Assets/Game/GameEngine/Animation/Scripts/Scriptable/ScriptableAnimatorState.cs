using UnityEngine;

namespace Game.GameEngine.Animation
{
    public sealed class ScriptableAnimatorState : StateMachineBehaviour
    {
        [SerializeField]
        private int stateId;
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.TryGetComponent(out AnimatorObservable eventDispatcher))
            {
                eventDispatcher.OnEnterState(stateInfo, this.stateId, layerIndex);
            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (animator.TryGetComponent(out AnimatorObservable eventDispatcher))
            {
                eventDispatcher.OnExitState(stateInfo, this.stateId, layerIndex);
            }
        }
    }
}