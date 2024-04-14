using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class Countdown : ICountdown, ISerializationCallbackReceiver
    {
        public event Action OnStarted;
        public event Action OnTimeChanged;
        public event Action OnStopped;
        public event Action OnEnded;
        public event Action OnReset;

        [ReadOnly]
        [ShowInInspector]
        [PropertyOrder(-10)]
        [PropertySpace(8)]
        public bool IsPlaying { get; private set; }

        [ReadOnly]
        [ShowInInspector]
        [PropertyOrder(-9)]
        [ProgressBar(0, 1)]
        public float Progress
        {
            get { return 1 - this.remainingTime / this.duration; }
            set { this.SetProgress(value); }
        }

        public float Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }

        [ReadOnly]
        [ShowInInspector]
        [PropertyOrder(-8)]
        public float RemainingTime
        {
            get { return this.remainingTime; }
            set { this.remainingTime = Mathf.Clamp(value, 0, this.duration); }
        }
        
        [Space]
        [SerializeField]
        private float duration;

        private float remainingTime;

        private Coroutine coroutine;

        public Countdown()
        {
        }

        public Countdown(float duration)
        {
            this.duration = duration;
            this.remainingTime = duration;
        }

        public void Play()
        {
            if (this.IsPlaying)
            {
                return;
            }

            this.IsPlaying = true;
            this.OnStarted?.Invoke();
            this.coroutine = MonoHelper.Instance.StartCoroutine(this.TimerRoutine());
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                MonoHelper.Instance.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }

            if (this.IsPlaying)
            {
                this.IsPlaying = false;
                this.OnStopped?.Invoke();
            }
        }

        public void ResetTime()
        {
            this.remainingTime = this.duration;
            this.OnReset?.Invoke();
        }

        private IEnumerator TimerRoutine()
        {
            while (this.remainingTime > 0)
            {
                yield return null;
                this.remainingTime -= Time.deltaTime;
                this.OnTimeChanged?.Invoke();
            }

            this.IsPlaying = false;
            this.OnEnded?.Invoke();
        }

        private void SetProgress(float progress)
        {
            progress = Mathf.Clamp01(progress);
            this.remainingTime = this.duration * (1 - progress);
            this.OnTimeChanged?.Invoke();
        }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            this.remainingTime = this.duration;
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize()
        {
        }
    }
}