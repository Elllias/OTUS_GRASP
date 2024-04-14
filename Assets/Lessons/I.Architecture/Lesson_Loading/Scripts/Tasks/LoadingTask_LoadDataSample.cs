using Cysharp.Threading.Tasks;
using Game.UI;
using GameSystem;
using Services;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_LoadDataSample",
        menuName = "Lessons/Tasks/New LoadingTask_LoadDataSample"
    )]
    public class LoadingTask_LoadDataSample : LoadingTask
    {
        [Range(0, 1)]
        [SerializeField]
        private float progress = 0.9f;
        
        private GameDataLoader dataLoader;
        
        [ServiceInject]
        public void Construct(GameDataLoader dataLoader)
        {
            this.dataLoader = dataLoader;
        }
        
        public async override UniTask<Result> Do()
        {
            //Загрузка данных:
            var ctx = GameObject.FindWithTag(nameof(GameContext)).GetComponent<GameContext>();
            await this.dataLoader.LoadData(ctx);
            LoadingScreen.ReportProgress(this.progress);
            
            return new Result
            {
                success = true
            };
        }
    }
}