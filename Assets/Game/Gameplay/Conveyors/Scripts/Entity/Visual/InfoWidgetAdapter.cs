using System;
using Elementary;
using Declarative;

namespace Game.Gameplay.Conveyors
{
    [Serializable]
    public sealed class InfoWidgetAdapter : 
        IAwakeListener,
        IEnableListener,
        IDisableListener
    {
        private ITimer workTimer;
        
        private InfoWidget view;

        public void Construct(ITimer workTimer, InfoWidget view)
        {
            this.workTimer = workTimer;
            this.view = view;
        }

        void IAwakeListener.Awake()
        {
            this.view.SetVisible(true);
            this.view.ProgressBar.SetVisible(this.workTimer.IsPlaying);
        }

        void IEnableListener.OnEnable()
        {
            this.workTimer.OnStarted += this.OnWorkStarted;
            this.workTimer.OnTimeChanged += this.OnWorkProgressChanged;
            this.workTimer.OnFinished += this.OnWorkFinished;
        }

        void IDisableListener.OnDisable()
        {
            this.workTimer.OnStarted -= this.OnWorkStarted;
            this.workTimer.OnTimeChanged -= this.OnWorkProgressChanged;
            this.workTimer.OnFinished -= this.OnWorkFinished;
        }

        private void OnWorkStarted()
        {
            this.view.ProgressBar.SetVisible(true);
        }

        private void OnWorkProgressChanged()
        {
            this.view.ProgressBar.SetProgress(this.workTimer.Progress);
        }

        private void OnWorkFinished()
        {
            this.view.ProgressBar.SetVisible(false);
        }
    }
}