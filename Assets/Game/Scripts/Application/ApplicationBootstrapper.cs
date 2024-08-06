using SampleGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scripts.Application
{
    public class ApplicationBootstrapper : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        private ApplicationExiter _applicationExiter;

        private UiSpawner _uiSpawner;

        [Inject]
        public void Construct(ApplicationExiter applicationFinisher, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _applicationExiter = applicationFinisher;
        }
        
        private async void Awake()
        {
            _uiSpawner = new UiSpawner();
            _uiSpawner.Construct(_applicationExiter, _sceneLoader);
            await _uiSpawner.Initialize();

            SceneManager.LoadScene("Menu");
        }
    }
}