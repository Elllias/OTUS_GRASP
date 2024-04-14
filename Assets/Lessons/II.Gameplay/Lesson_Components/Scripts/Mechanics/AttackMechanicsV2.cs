using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class AttackMechanicsV2 : MonoBehaviour
    {
        [SerializeField]
        private EntityEventReceiver attackReceiver;

        [SerializeField]
        private TimerBehaviour countdown;

        [SerializeField]
        private IntBehaviour damage;

        private void OnEnable()
        {
            this.attackReceiver.OnEvent += this.OnRequiestAttack;
        }

        private void OnDisable()
        {
            this.attackReceiver.OnEvent -= this.OnRequiestAttack;
        }

        private void OnRequiestAttack(Entity target)
        {
            if (this.countdown.IsPlaying)
            {
                return;
            }

            //Нанесение урона противнику: 
            target.Get<ITakeDamageComponent>().TakeDamage(this.damage.Value);

            //Запуск перезарядки:
            this.countdown.ResetTime();
            this.countdown.Play();
        }
    }
}