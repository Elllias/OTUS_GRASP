using UnityEngine;

namespace Lessons.Architecture.Mechanics
{
    public sealed class RestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField]
        private IntEventReceiver takeDamageReceiver;

        [SerializeField]
        private IntBehaviour hitPoints;

        [SerializeField]
        private TimerBehaviour delay;

        [SerializeField]
        private PeriodBehaviour restorePeriod;

        private void OnEnable()
        {
            this.takeDamageReceiver.OnEvent += this.OnDamageTaken;
            this.delay.OnEnded += this.OnDelayEnded;
            this.restorePeriod.OnEvent += this.OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            this.takeDamageReceiver.OnEvent -= this.OnDamageTaken;
            this.delay.OnEnded -= this.OnDelayEnded;
            this.restorePeriod.OnEvent -= this.OnRestoreHitPoints;
        }

        private void OnDamageTaken(int damage)
        {
            //Сброс задержки:
            this.delay.ResetTime();
            if (!this.delay.IsPlaying)
            {
                this.delay.Play();
            }
            
            this.restorePeriod.Stop();
        }

        private void OnDelayEnded()
        {
            this.restorePeriod.Play();
        }

        private void OnRestoreHitPoints()
        {
            this.hitPoints.Value+= 1;
            if (this.hitPoints.Value >= 5)
            {
                this.restorePeriod.Stop();
            }
        }
    }
}