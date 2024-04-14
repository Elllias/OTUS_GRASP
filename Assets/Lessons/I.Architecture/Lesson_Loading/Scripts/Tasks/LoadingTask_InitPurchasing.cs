using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.UI;
using Purchasing;
using Services;
using Unity.Services.Core;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_InitPurchasing",
        menuName = "Lessons/Tasks/New LoadingTask_InitPurchasing"
    )]
    public sealed class LoadingTask_InitPurchasing : LoadingTask
    {
        [SerializeField]
        private string error = "Встроенные покупки не загружены!";

        [Range(0, 1)]
        [SerializeField]
        private float progress = 0.1f;

        private PurchaseManager purchaseManager;

        [ServiceInject]
        public void Construct(PurchaseManager purchaseManager)
        {
            this.purchaseManager = purchaseManager;
        }

        public async override UniTask<Result> Do()
        {
            await UnityServices.InitializeAsync();

            var tcs = new TaskCompletionSource<Result>();
            
            this.purchaseManager.Initialize(result =>
            {
                tcs.SetResult(new Result
                {
                    success = result.isSuccess,
                    error = this.error,
                });
                
                LoadingScreen.ReportProgress(this.progress);
            });

            return await tcs.Task;
        }
    }
}