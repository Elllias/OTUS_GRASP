using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class AttackMechanics : MonoBehaviour
    {
        [SerializeField]
        private MonoEmitter attackReceiver;

        [SerializeField]
        private MonoTimer countdown;

        [SerializeField]
        private MonoBoolVariable isAttack;

        private void OnEnable()
        {
            this.attackReceiver.OnEvent += this.OnAttackRequest;
        }

        private void OnDisable()
        {
            this.attackReceiver.OnEvent -= this.OnAttackRequest;
        }

        private void OnAttackRequest()
        {
            if (this.isAttack.Current)
            {
                return;
            }
            
            if (this.countdown.IsPlaying)
            {
                return;
            }

            this.isAttack.SetTrue();
            this.countdown.ResetTime();
            this.countdown.Play();
        }
    }
}