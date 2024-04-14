using System;
using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;

namespace Game.App
{
    public sealed class GameTask_LoadInterface : ILoadingTask
    {
        async void ILoadingTask.Do(Action<LoadingResult> callback)
        {
            var gameSystem = GameObject.FindObjectOfType<GameContext>();
            await GameInterfaceDeployer.DeployInterface(gameSystem);
            callback?.Invoke(LoadingResult.Success());
        }
    }
}