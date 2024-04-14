using Elementary;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Hit Points/Mechanics «Restore Hit Points»")]
    public sealed class URestoreHitPointsMechanics : MonoBehaviour
    {
        [SerializeField]
        public UTakeDamageEngine takeDamageEngine;

        [SerializeField]
        public UHitPoints hitPointsEngine;

        [SerializeField]
        [FormerlySerializedAs("countdown")]
        public MonoCountdown delay;

        [SerializeField]
        public MonoPeriod restorePeriod;

        [Space]
        [SerializeField]
        [FormerlySerializedAs("restoreHitPoinsPerOne")]
        public IntAdapter restoreAtTime;

        private void OnEnable()
        {
            this.takeDamageEngine.OnDamageTaken += this.OnDamageTaken;
            this.delay.OnEnded += this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent += this.OnRestoreHitPoints;
        }

        private void OnDisable()
        {
            this.takeDamageEngine.OnDamageTaken -= this.OnDamageTaken;
            this.delay.OnEnded -= this.OnDelayEnded;
            this.restorePeriod.OnPeriodEvent -= this.OnRestoreHitPoints;
        }

        private void OnDamageTaken(TakeDamageArgs damageArgs)
        {
            if (this.hitPointsEngine.Current <= 0)
            {
                return;
            }

            //Сброс задержки:
            this.delay.ResetTime();
            if (!this.delay.IsPlaying)
            {
                this.delay.Play();
            }

            //Сброс периода:
            this.restorePeriod.Stop();
        }

        private void OnDelayEnded()
        {
            this.restorePeriod.Play();
        }

        private void OnRestoreHitPoints()
        {
            this.hitPointsEngine.Current += this.restoreAtTime.Current;
            if (this.hitPointsEngine.Current >= this.hitPointsEngine.Max)
            {
                this.restorePeriod.Stop();
            }
        }
    }
}