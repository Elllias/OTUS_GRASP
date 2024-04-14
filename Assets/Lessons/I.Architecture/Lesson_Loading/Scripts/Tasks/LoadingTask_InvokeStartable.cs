using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Services;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_InvokeStartable",
        menuName = "Lessons/Tasks/New LoadingTask_InvokeStartable"
    )]
    public sealed class LoadingTask_InvokeStartable : LoadingTask
    {
        private IAppStartable[] startables;

        [ServiceInject]
        public void Construct(IAppStartable[] startables)
        {
            this.startables = startables;
        }

        public override UniTask<Result> Do()
        {
            foreach (var startable in this.startables)
            {
                startable.Start();
            }

            return UniTask.FromResult(new Result
            {
                success = true
            });
        }
    }
}