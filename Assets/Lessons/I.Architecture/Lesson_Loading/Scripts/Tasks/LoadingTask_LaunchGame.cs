using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.UI;
using GameSystem;
using Services;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_LaunchGame",
        menuName = "Lessons/Tasks/New LoadingTask_LaunchGame"
    )]
    public sealed class LoadingTask_LaunchGame : LoadingTask
    {
        public override UniTask<Result> Do()
        {
            var ctx = GameObject.FindWithTag(nameof(GameContext)).GetComponent<GameContext>();

            //Запуск игры:
            ctx.InitGame();
            ctx.ReadyGame();
            ctx.StartGame();

            return UniTask.FromResult(new Result
            {
                success = true
            });
        }
    }
}