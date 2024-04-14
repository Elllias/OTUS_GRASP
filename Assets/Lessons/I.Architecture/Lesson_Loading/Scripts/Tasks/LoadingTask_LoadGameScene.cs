using System.Collections;
using System.Threading.Tasks;
using Asyncoroutine;
using Cysharp.Threading.Tasks;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_LoadGameScene",
        menuName = "Lessons/Tasks/New LoadingTask_LoadGameScene"
    )]
    public sealed class LoadingTask_LoadGameScene : LoadingTask
    {
        public async override UniTask<Result> Do()
        {
            await this.LoadGameScene();
            return await Task.FromResult(new Result
            {
                success = true
            });
        }

        private IEnumerator LoadGameScene()
        {
            var operation = SceneManager.LoadSceneAsync("Game/Scenes/GameScene");
            while (!operation.isDone)
            {
                LoadingScreen.ReportProgress(operation.progress / 2);
                yield return null;
            }
        }
    }
}