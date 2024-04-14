using System;
using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.Mech
{
    public sealed class ConveyorWidgetAdapter : MonoBehaviour
    {
        [SerializeField]
        private ConveyorWidget view;

        [SerializeField]
        private MonoTimer timer;

        private void OnEnable()
        {
            this.timer.OnStarted += this.OnWorkStarted;
            this.timer.OnFinished += this.OnWorkFinished;
        }
        
        private void OnDisable()
        {
            this.timer.OnStarted -= this.OnWorkStarted;
            this.timer.OnFinished -= this.OnWorkFinished;
        }

        private void OnWorkStarted()
        {
            this.timer.OnTimeChanged += this.OnWorkProgress;
            this.view.SetVisible(true);
        }

        private void OnWorkProgress()
        {
            this.view.SetProgress(this.timer.Progress);
        }

        private void OnWorkFinished()
        {
            this.timer.OnTimeChanged -= this.OnWorkProgress;
            this.view.SetVisible(false);
        }
    }
}