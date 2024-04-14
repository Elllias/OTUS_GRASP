using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Services;
using UnityEngine;

namespace Game.App
{
    public sealed class GameLauncher
    {
        private const string LAUNCH_PIPELINE = "GameLaunch (Pipeline)";

        public async UniTask LaunchGame()
        {
            var taskPipeline = Resources.Load<LoadingPipeline>(LAUNCH_PIPELINE);
            var taskList = taskPipeline.GetTaskList();
            for (int i = 0, count = taskList.Length; i < count; i++)
            {
                var taskType = taskList[i];
                await DoTask(taskType);
            }
        }

        private static UniTask<LoadingResult> DoTask(Type taskType)
        {
            var tcs = new UniTaskCompletionSource<LoadingResult>();
            var loadingTask = (ILoadingTask) ServiceInjector.Instantiate(taskType);
            loadingTask.Do(result => tcs.TrySetResult(result));
            return tcs.Task;
        }
    }
}