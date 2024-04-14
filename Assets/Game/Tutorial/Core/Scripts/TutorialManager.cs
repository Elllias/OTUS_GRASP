using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Tutorial
{
    [AddComponentMenu("Tutorial/Tutorial Manager")]
    public sealed class TutorialManager : MonoBehaviour
    {
        public event Action<TutorialStep> OnStepFinished;

        public event Action<TutorialStep> OnNextStep;

        public event Action OnCompleted;

        public bool IsCompleted
        {
            get { return this.isCompleted; }
        }

        public TutorialStep CurrentStep
        {
            get { return this.stepList[this.currentIndex]; }
        }

        public int CurrentIndex
        {
            get { return this.currentIndex; }
        }

        internal static TutorialManager Instance { get; private set; }

        [SerializeField, FormerlySerializedAs("config")]
        private TutorialList stepList;

        private int currentIndex;

        private bool isCompleted;

        private void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("TutorialManager is already created!");
            }

            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        public void Initialize(bool isCompleted = false, int stepIndex = 0)
        {
            this.isCompleted = isCompleted;
            this.currentIndex = Mathf.Clamp(stepIndex, 0, this.stepList.LastIndex);
        }

        public void FinishCurrentStep()
        {
            if (!this.isCompleted)
            {
                this.OnStepFinished?.Invoke(this.CurrentStep);
            }
        }

        public void MoveToNextStep()
        {
            if (this.isCompleted)
            {
                return;
            }

            if (this.stepList.IsLast(this.currentIndex))
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
            if (this.isCompleted)
            {
                return true;
            }

            return this.stepList.IndexOf(step) < this.currentIndex;
        }

        public int IndexOfStep(TutorialStep step)
        {
            return this.stepList.IndexOf(step);
        }
    }
}