using SampleGame;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SampleGame
{
    public sealed class MenuScreen : MonoBehaviour
    {
        [SerializeField]
        private Button startButton;

        [SerializeField]
        private Button exitButton;
        
        private ApplicationExiter applicationExiter;
        private SceneLoader sceneLoader;
        
        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, SceneLoader sceneLoader)
        {
            this.sceneLoader = sceneLoader;
            this.applicationExiter = applicationFinisher;
        }

        private void OnEnable()
        {
            this.startButton.onClick.AddListener(OnStartButtonClicked);
            this.exitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnDisable()
        {
            this.startButton.onClick.RemoveListener(OnStartButtonClicked);
            this.exitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        private void OnStartButtonClicked()
        {
            sceneLoader.LoadGame();
        }
        
        private void OnExitButtonClicked()
        {
            applicationExiter.ExitApp();
        }
    }
}