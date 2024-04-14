using GameSystem;
using UnityEngine;

namespace Lessons.Tutorial
{
    public abstract class StepObserver : MonoBehaviour,
        IGameConstructElement,
        IGameStartElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private TutorialManager tutorialManager;

        [SerializeField]
        private TutorialStep step;

        protected virtual void InitGame(GameContext context, bool isStepPassed)
        {
        }

        protected virtual void OnStartStep()
        {
        }

        protected virtual void OnFinishStep()
        {
        }

        protected void FinishStep()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.FinishCurrentStep();
            }
        }

        protected void MoveNext()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.MoveToNextStep();
            }
        }

        protected void FinishStepAndMoveNext()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.FinishCurrentStep();
                this.tutorialManager.MoveToNextStep();
            }
        }

        #region GameEvents

        public void ConstructGame(GameContext context)
        {
            this.tutorialManager = context.GetService<TutorialManager>();
            var isStepFinished = this.tutorialManager.IsStepPassed(this.step);
            this.InitGame(context, isStepFinished);
        }

        public virtual void ReadyGame()
        {
            this.tutorialManager.OnStepFinished += this.CheckForFinish;
            this.tutorialManager.OnNextStep += this.CheckForStart;
        }

        public virtual void StartGame()
        {
            var stepFinished = this.tutorialManager.IsStepPassed(this.step);
            if (!stepFinished)
            {
                this.CheckForStart(this.tutorialManager.CurrentStep);
            }
        }

        public virtual void FinishGame()
        {
            this.tutorialManager.OnStepFinished -= this.CheckForFinish;
            this.tutorialManager.OnNextStep -= this.CheckForStart;
        }

        #endregion

        private void CheckForFinish(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnFinishStep();
            }
        }

        private void CheckForStart(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnStartStep();
            }
        }
    }
}