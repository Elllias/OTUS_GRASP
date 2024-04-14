using Cysharp.Threading.Tasks;
using GameSystem;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_InitGame",
        menuName = "Lessons/Tasks/New LoadingTask_InitGame"
    )]
    public sealed class LoadingTask_InitGame : LoadingTask
    {
        public override UniTask<Result> Do()
        {
            Debug.Log("INIT GAME");
            //Инициализация игровой системы:
            var ctx = GameObject.FindWithTag(nameof(GameContext)).GetComponent<GameContext>();
            ctx.ConstructGame();
            return UniTask.FromResult(new Result
            {
                success = true
            });
        }
    }
}