using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class AnimatorStateResolver : MonoBehaviour
    {
        [SerializeField]
        private MonoBoolVariable isAttack;

        [Space]
        [SerializeField]
        private AnimatorSystem animator;

        private void Awake()
        {
            this.UpdateState(this.isAttack.Current);
        }

        private void OnEnable()
        {
            this.isAttack.OnValueChanged += this.OnStateChanged;
        }

        private void OnDisable()
        {
            this.isAttack.OnValueChanged -= this.OnStateChanged;
        }

        private void OnStateChanged(bool isTrue)
        {
            UpdateState(isTrue);
        }

        private void UpdateState(bool isTrue)
        {
            if (isTrue)
            {
                this.animator.SwitchState(AnimatorStateType.ATTACK);
            }
            else
            {
                this.animator.SwitchState(AnimatorStateType.IDLE);
            }
        }
    }
}