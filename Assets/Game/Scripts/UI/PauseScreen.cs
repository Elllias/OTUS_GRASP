using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class PauseScreen : MonoBehaviour
    {
        [SerializeField]
        private Button resumeButton;

        [SerializeField]
        private Button exitButton;

        private SceneLoader sceneLoader;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            this.resumeButton.onClick.AddListener(this.Hide);
            this.exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDisable()
        {
            this.resumeButton.onClick.RemoveListener(this.Hide);
            this.exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
        }

        private void OnExitButtonClicked()
        {
            sceneLoader.LoadMenu();
        }
    }
}