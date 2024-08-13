using SampleGame;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scripts.Application
{
    public class ApplicationBootstrapper : MonoBehaviour
    {
        private UiSpawner _uiSpawner;
        private DiContainer _diContainer;

        [Inject]
        public void Construct(DiContainer container)
        {
            _diContainer = container;
        }
        
        private async void Awake()
        {
            _uiSpawner = _diContainer.Instantiate<UiSpawner>();
            await _uiSpawner.Initialize();

            SceneManager.LoadScene("Menu");
        }
    }
}