using GameSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Tutorial.Gameplay
{
    public abstract class TutorialStepController : MonoBehaviour,
        IGameConstructElement,
        IGameReadyElement,
        IGameStartElement,
        IGameFinishElement
    {
        [FormerlySerializedAs("step")]
        [SerializeField]
        private TutorialStep step;

        private TutorialManager tutorialManager;

        public virtual void ConstructGame(GameContext context)
        {
            this.tutorialManager = TutorialManager.Instance;
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

        protected virtual void OnStart()
        {
        }

        protected virtual void OnStop()
        {
        }

        protected void NotifyAboutComplete()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.FinishCurrentStep();
            }
        }

        protected void NotifyAboutMoveNext()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.MoveToNextStep();
            }
        }

        protected void NotifyAboutCompleteAndMoveNext()
        {
            if (this.tutorialManager.CurrentStep == this.step)
            {
                this.tutorialManager.FinishCurrentStep();
                this.tutorialManager.MoveToNextStep();
            }
        }

        protected bool IsStepFinished()
        {
            return this.tutorialManager.IsStepPassed(this.step);
        }

        private void CheckForFinish(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnStop();
            }
        }

        private void CheckForStart(TutorialStep step)
        {
            if (this.step == step)
            {
                this.OnStart();
            }
        }
    }
}