using System;
using System.Collections;
using UnityEngine;

namespace Game.Meta
{
    public sealed class BoosterViewAdapter
    {
        private readonly BoosterView view;

        private readonly Booster booster;

        private readonly MonoBehaviour coroutineDispatcher;

        private Coroutine timeCoroutine;

        public BoosterViewAdapter(BoosterView view, Booster booster, MonoBehaviour coroutineDispatcher)
        {
            this.view = view;
            this.booster = booster;
            this.coroutineDispatcher = coroutineDispatcher;
        }

        public void Show()
        {
            var metadata = this.booster.Metadata;
            this.view.SetIcon(metadata.icon);
            this.view.SetLabel(metadata.viewLabel);
            this.view.SetColor(metadata.viewColor);
            
            this.UpdateRemainingTime();

            this.timeCoroutine = this.coroutineDispatcher.StartCoroutine(this.UpdateTimeRoutine());
        }

        public void Hide()
        {
            if (this.timeCoroutine != null)
            {
                this.coroutineDispatcher.StopCoroutine(this.timeCoroutine);
                this.timeCoroutine = null;
            }
        }

        private IEnumerator UpdateTimeRoutine()
        {
            var period = new WaitForSeconds(1);
            while (true)
            {
                yield return period;
                this.UpdateRemainingTime();
            }
        }

        private void UpdateRemainingTime()
        {
            var remainingTime = this.booster.RemainingTime;
            var progress = remainingTime / this.booster.Duration;
            this.view.SetProgress(progress);

            var timeSpan = TimeSpan.FromSeconds(remainingTime);
            var remainingText = string.Format("{0:D1}h:{1:D2}m:{2:D2}s",
                timeSpan.Hours,
                timeSpan.Minutes,
                timeSpan.Seconds
            );
            this.view.SetRemainingText(remainingText);
        }
    }
}