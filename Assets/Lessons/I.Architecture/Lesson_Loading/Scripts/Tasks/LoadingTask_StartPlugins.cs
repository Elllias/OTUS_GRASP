using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_StartPlugins",
        menuName = "Lessons/Tasks/New LoadingTask_StartPlugins"
    )]
    public sealed class LoadingTask_StartPlugins : LoadingTask
    {
        public override UniTask<Result> Do()
        {
            AppsFlyer.startSDK();

            var tcs = new UniTaskCompletionSource<Result>();
            
            FB.Init(
                onSuccess: () => tcs.TrySetResult(new Result
                {
                    success = true,
                }),
                onError: err => tcs.TrySetResult(new Result
                {
                    success = false,
                    error = err,
                })
            );

            return tcs.Task;
        }
    }
}