using System;
using System.Collections;
using Asyncoroutine;
using Game.UI;
using GameSystem;
using Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.App
{
    public sealed class GameTask_LoadScene : ILoadingTask
    {
        private const string GAME_SCENE = "GameScene";
        
        private readonly GameFacade gameFacade;

        [ServiceInject]
        public GameTask_LoadScene(GameFacade gameFacade)
        {
            this.gameFacade = gameFacade;
        }

        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            await LoadScene();
            
            var gameContext = GameObject.FindObjectOfType<GameContext>();
            this.gameFacade.SetupGame(gameContext);
            
            callback?.Invoke(LoadingResult.Success());
        }

        private static IEnumerator LoadScene()
        {
            var operation = SceneManager.LoadSceneAsync(GAME_SCENE, LoadSceneMode.Single);
            
            while (!operation.isDone)
            {
                LoadingScreen.ReportProgress(0.3f + operation.progress / 2);
                yield return null;
            }
            
            LoadingScreen.ReportProgress(0.8f);
        }
    }
}