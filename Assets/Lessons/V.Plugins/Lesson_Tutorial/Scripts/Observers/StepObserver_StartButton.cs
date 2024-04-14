using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Tutorial
{
    public sealed class StepObserver_StartButton : StepObserver
    {
        [SerializeField]
        private Button buttonStart;

        private void Awake()
        {
            this.buttonStart.gameObject.SetActive(false);
        }

        protected override void OnStartStep()
        {
            this.buttonStart.gameObject.SetActive(true);
            this.buttonStart.onClick.AddListener(this.OnButtonClicked);
        }

        protected override void OnFinishStep()
        {
            this.buttonStart.gameObject.SetActive(false);
            this.buttonStart.onClick.RemoveListener(this.OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            this.FinishStepAndMoveNext();
        }
    }
}