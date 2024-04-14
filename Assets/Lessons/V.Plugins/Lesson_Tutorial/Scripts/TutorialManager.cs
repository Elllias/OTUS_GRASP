using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Tutorial
{
    public sealed class TutorialManager : MonoBehaviour
    {
        public event Action<TutorialStep> OnStepFinished
        {
            add { this.iterator.OnStepFinished += value; }
            remove { this.iterator.OnStepFinished -= value; }
        }

        public event Action<TutorialStep> OnNextStep
        {
            add { this.iterator.OnNextStep += value; }
            remove { this.iterator.OnNextStep -= value; }
        }

        public event Action OnCompleted
        {
            add { this.iterator.OnCompleted += value; }
            remove { this.iterator.OnCompleted -= value; }
        }

        [PropertySpace]
        [ReadOnly]
        [ShowInInspector]
        public bool IsCompleted
        {
            get { return this.iterator.IsCompleted; }
        }

        [ReadOnly]
        [ShowInInspector]
        public TutorialStep CurrentStep
        {
            get { return this.iterator.CurrentStep; }
        }

        private readonly TutorialIterator iterator;

        public TutorialManager()
        {
            var steps = new List<TutorialStep>
            {
                TutorialStep.START_TUTORIAL,
                TutorialStep.MINE_STONE,
                TutorialStep.KILL_ENEMY
            };
            this.iterator = new TutorialIterator(steps);
        }

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void FinishCurrentStep()
        {
            this.iterator.FinishCurrentStep();
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void MoveToNextStep()
        {
            this.iterator.MoveToNextStep();
        }

        public bool IsStepPassed(TutorialStep step)
        {
            return this.iterator.IsStepPassed(step);
        }

        public int IndexOfStep(TutorialStep step)
        {
            return this.iterator.IndexOfStep(step);
        }
    }
}