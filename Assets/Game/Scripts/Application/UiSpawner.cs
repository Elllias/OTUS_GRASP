using System.Collections.Generic;
using System.Threading.Tasks;
using Game.Scripts.Application.Configs;
using SampleGame;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Scripts.Application
{
    public class UiSpawner
    {
        private const string MENU_SCENE_NAME = "Menu";
        private const string GAME_SCENE_NAME = "Game";
        
        private readonly DiContainer _diContainer;
        private readonly UiAssetConfig _uiAssetConfig;

        private readonly Dictionary<string, GameObject> _uiDictionary = new();

        public UiSpawner(DiContainer diContainer, UiAssetConfig uiAssetConfig)
        {
            _diContainer = diContainer;
            _uiAssetConfig = uiAssetConfig;
        }

        public async Task Initialize()
        {
            await InitializeMenuScreenObject();
            await InitializeGameScreenObject();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private async Task InitializeMenuScreenObject()
        {
            var menuScreenHandle = Addressables.LoadAssetAsync<GameObject>(_uiAssetConfig.GetMenuUiAsset());
            await menuScreenHandle.Task;
            
            _uiDictionary[MENU_SCENE_NAME] = menuScreenHandle.Result;
        }
        
        private async Task InitializeGameScreenObject()
        {
            var pauseScreenHandle = Addressables.LoadAssetAsync<GameObject>(_uiAssetConfig.GetGameUiAsset());
            await pauseScreenHandle.Task;
            
            _uiDictionary[GAME_SCENE_NAME] = pauseScreenHandle.Result;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode _)
        {
            var ui = Object.Instantiate(_uiDictionary[scene.name]);

            switch (scene.name)
            {
                case MENU_SCENE_NAME:
                    _diContainer.Inject(ui.GetComponentInChildren<MenuScreen>(true));
                    break;
                case GAME_SCENE_NAME:
                    _diContainer.Inject(ui.GetComponentInChildren<PauseScreen>(true));
                    break;
            }
        }
    }
}