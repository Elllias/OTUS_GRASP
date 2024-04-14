using Game.UI;
using UnityEngine;

namespace Game.GameEngine
{
    [AddComponentMenu("GameEngine/Mechanics/Time/Timer Mechanics «Update Progress Bar»")]
    public sealed class UTimerMechanics_UpdateProgressBar : UTimerMechanics
    {
        [SerializeField]
        public ProgressBar progressBar;

        #region Lifecycle

        private void Awake()
        {
            this.progressBar.SetVisible(false);
        }

        #endregion

        #region Callbacks

        protected override void OnTimerStarted()
        {
            this.progressBar.SetProgress(this.timer.Progress);
        }

        protected override void OnTimeChanged()
        {
            var progress = this.timer.Progress;
            this.progressBar.SetProgress(progress);
        }

        protected override void OnTimerFinished()
        {
            this.progressBar.SetProgress(1.0f);
        }

        protected override void OnTimerCanceled()
        {
            this.progressBar.SetVisible(false);
        }

        #endregion
    }
}