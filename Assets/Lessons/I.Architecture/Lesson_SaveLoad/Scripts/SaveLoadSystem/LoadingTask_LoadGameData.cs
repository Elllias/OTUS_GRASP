using Cysharp.Threading.Tasks;
using Lessons.Architecture.Loading;
using Services;
using UnityEngine;

namespace Lessons.Architecture.SaveLoad
{
    [CreateAssetMenu(
        fileName = "LoadingTask_LoadGameData",
        menuName = "Lessons/Tasks/New LoadingTask_LoadGameData"
    )]
    public sealed class LoadingTask_LoadGameData : LoadingTask
    {
        private SaveLoadManager saveLoadManager;

        [ServiceInject]
        public void Construct(SaveLoadManager saveLoadManager)
        {
            this.saveLoadManager = saveLoadManager;
        }

        public override UniTask<Result> Do()
        {
            this.saveLoadManager.Load();
            return UniTask.FromResult<Result>(new Result {success = true});
        }
    }
}