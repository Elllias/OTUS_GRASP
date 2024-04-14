using System.Threading.Tasks;
using Asyncoroutine;
using Cysharp.Threading.Tasks;
using Game.UI;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_FinishLoading",
        menuName = "Lessons/Tasks/New LoadingTask_FinishLoading"
    )]
    public sealed class LoadingTask_FinishLoading : LoadingTask
    {
        [SerializeField]
        private float delay = 0.5f;
        
        public override async UniTask<Result> Do()
        {
            LoadingScreen.ReportProgress(1f);
            await new WaitForSeconds(this.delay);
            LoadingScreen.Hide();

            return await Task.FromResult<Result>(new Result
            {
                success = true
            });
        }
    }
}