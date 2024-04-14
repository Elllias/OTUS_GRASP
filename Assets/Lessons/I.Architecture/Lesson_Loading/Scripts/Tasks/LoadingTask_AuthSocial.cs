using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.UI;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_AuthSocial",
        menuName = "Lessons/Tasks/New LoadingTask_AuthSocial"
    )]
    public sealed class LoadingTask_AuthSocial : LoadingTask
    {
        [SerializeField]
        private string error = "Ошибка авторизации!";

        [Range(0, 1)]
        [SerializeField]
        private float progress = 0.2f;
        
        public override UniTask<Result> Do()
        {
            var tcs = new UniTaskCompletionSource<Result>();
            
            Social.localUser.Authenticate(success =>
            {
                tcs.TrySetResult(new Result
                {
                    success = success,
                    error = this.error,
                });
                
                LoadingScreen.ReportProgress(this.progress);
            });

            return tcs.Task;
        }
    }
}