using Elementary;
using UnityEngine;

namespace Game.GameEngine
{
    public abstract class UTimerMechanics : MonoBehaviour
    {
        [SerializeField]
        public MonoTimer timer;

        protected virtual void OnEnable()
        {
            this.timer.OnStarted += this.OnTimerStarted;
            this.timer.OnTimeChanged += this.OnTimeChanged;
            this.timer.OnFinished += this.OnTimerFinished;
            this.timer.OnCanceled += this.OnTimerCanceled;
        }

        protected virtual void OnDisable()
        {
            this.timer.OnStarted -= this.OnTimerStarted;
            this.timer.OnTimeChanged -= this.OnTimeChanged;
            this.timer.OnFinished -= this.OnTimerFinished;
            this.timer.OnCanceled -= this.OnTimerCanceled;
        }

        protected virtual void OnTimerStarted()
        {
        }

        protected virtual void OnTimeChanged()
        {
        }

        protected virtual void OnTimerFinished()
        {
        }

        protected virtual void OnTimerCanceled()
        {
        }
    }
}