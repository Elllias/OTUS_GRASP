using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class TimerBehaviour : MonoBehaviour
    {
        public event Action OnEnded;

        public bool IsPlaying
        {
            get { return this.timerCoroutine != null; }
        }

        [SerializeField]
        private float duration = 3;

        [ReadOnly]
        [SerializeField]
        private float currentTime;

        private Coroutine timerCoroutine;

        public void Play()
        {
            if (this.timerCoroutine == null)
            {
                this.timerCoroutine = this.StartCoroutine(this.TimerRoutine());
            }
        }

        public void Stop()
        {
            if (this.timerCoroutine != null)
            {
                this.StopCoroutine(this.timerCoroutine);
                this.timerCoroutine = null;
            }
        }

        public void ResetTime()
        {
            this.currentTime = 0;
        }

        private IEnumerator TimerRoutine()
        {
            while (this.currentTime < this.duration)
            {
                yield return null;
                this.currentTime += Time.deltaTime;
            }

            this.currentTime = this.duration;
            this.timerCoroutine = null;
            this.OnEnded?.Invoke();
        }
    }
}