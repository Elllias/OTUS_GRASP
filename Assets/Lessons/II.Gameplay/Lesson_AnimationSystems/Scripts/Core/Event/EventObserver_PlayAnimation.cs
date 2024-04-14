using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class EventObserver_PlayAnimation : AbstractEventObserver
    {
        [SerializeField]
        private Animator animator;

        [SerializeField]
        private string animationName;
        
        protected override void OnEvent()
        {
            this.animator.Play(stateName: this.animationName, layer: -1, normalizedTime: 0);
        }
    }
}