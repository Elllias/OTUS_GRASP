using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Elementary
{
    [Serializable]
    public sealed class Period : IPeriod
    {
        public event Action OnStarted;

        public event Action OnPeriodEvent;

        public event Action OnStoped;

        [PropertyOrder(-10)]
        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        public bool IsActive
        {
            get { return this.coroutine != null; }
        }

        public float Duration
        {
            get { return this.period; }
            set { this.period = value; }
        }

        [SerializeField]
        private float period;

        private Coroutine coroutine;

        public Period()
        {
        }

        public Period(float period)
        {
            this.period = period;
        }

        public void Play()
        {
            if (this.coroutine == null)
            {
                this.coroutine = MonoHelper.Instance.StartCoroutine(this.PeriodRoutine());
                this.OnStarted?.Invoke();
            }
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                MonoHelper.Instance.StopCoroutine(this.coroutine);
                this.coroutine = null;
                this.OnStoped?.Invoke();
            }
        }

        private IEnumerator PeriodRoutine()
        {
            var period = new WaitForSeconds(this.period);
            while (true)
            {
                yield return period;
                this.OnPeriodEvent?.Invoke();
            }
        }
    }
}