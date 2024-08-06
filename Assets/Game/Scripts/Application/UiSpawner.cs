using System.Threading.Tasks;
using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Application
{
    public class UiSpawner
    {
        private GameObject _menuScreenObject;
        private GameObject _pauseScreenObject;

        private SceneLoader _sceneLoader;
        private ApplicationExiter _applicationExiter;

        public void Construct(ApplicationExiter applicationFinisher, SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
            _applicationExiter = applicationFinisher;
        }

        public async Task Initialize()
        {
            var menuScreenHandle = Addressables.LoadAssetAsync<GameObject>("MENU_UI");
            var pauseScreenHandle = Addressables.LoadAssetAsync<GameObject>("GAME_UI");

            await menuScreenHandle.Task;
            await pauseScreenHandle.Task;

            _menuScreenObject = menuScreenHandle.Result;
            _pauseScreenObject = pauseScreenHandle.Result;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode _)
        {
            if (scene.name == "Menu")
            {
                var ui = Object.Instantiate(_menuScreenObject);
                ui.GetComponentInChildren<MenuScreen>(true).Construct(_applicationExiter, _sceneLoader);
            }
            else if (scene.name == "Game")
            {
                var ui = Object.Instantiate(_pauseScreenObject);
                ui.GetComponentInChildren<PauseScreen>(true).Construct(_sceneLoader);
            }
        }
    }
}