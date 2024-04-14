using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public sealed class AttackMechanics : MonoBehaviour
    {
        [SerializeField]
        private EventReceiver attackReceiver;

        [SerializeField]
        private TimerBehaviour countdown;

        [SerializeField]
        private IntBehaviour damage;

        [Space]
        [SerializeField]
        private Enemy enemy;

        private void OnEnable()
        {
            this.attackReceiver.OnEvent += this.OnRequiestAttack;
        }

        private void OnDisable()
        {
            this.attackReceiver.OnEvent -= this.OnRequiestAttack;
        }

        private void OnRequiestAttack()
        {
            if (this.countdown.IsPlaying)
            {
                return;
            }

            //Логика нанесения урона противнику:
            //Урон
            this.enemy.TakeDamage(this.damage.Value);

            //Сбросить и запустить таймер снова:
            this.countdown.ResetTime();
            this.countdown.Play();
        }
    }
}