using System;
using System.Collections.Generic;

namespace Lessons.Tutorial
{
    public sealed class TutorialIterator
    {
        public event Action<TutorialStep> OnStepFinished;

        public event Action<TutorialStep> OnNextStep;

        public event Action OnCompleted;

        public TutorialStep CurrentStep
        {
            get { return this.stepList[this.currentIndex]; }
        }

        public bool IsCompleted
        {
            get { return this.isCompleted; }
        }

        private readonly List<TutorialStep> stepList;

        private int currentIndex;

        private bool isCompleted;

        public TutorialIterator(List<TutorialStep> stepList)
        {
            this.stepList = new List<TutorialStep>(stepList);
            this.isCompleted = false;
            this.currentIndex = 0;
        }

        public void FinishCurrentStep()
        {
            if (this.isCompleted)
            {
                return;
            }
            
            this.OnStepFinished?.Invoke(this.CurrentStep);
        }

        public void MoveToNextStep()
        {
            if (this.isCompleted)
            {
                return;
            }

            if (this.currentIndex >= this.stepList.Count - 1)
            {
                this.isCompleted = true;
                this.OnCompleted?.Invoke();
                return;
            }

            this.currentIndex++;
            this.OnNextStep?.Invoke(this.CurrentStep);
        }

        public bool IsStepPassed(TutorialStep step)
        {
            var index = this.stepList.IndexOf(step);
            return index < this.currentIndex;
        }

        public int IndexOfStep(TutorialStep step)
        {
            return this.stepList.IndexOf(step);
        }
    }
}