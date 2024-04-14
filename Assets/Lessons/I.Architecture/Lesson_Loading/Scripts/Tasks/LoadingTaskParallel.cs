using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTaskParallel",
        menuName = "Lessons/Tasks/New LoadingTaskParallel"
    )]
    public class LoadingTaskParallel : LoadingTask
    {
        [SerializeField]
        private LoadingTask[] loadingTasks;
        
        public async override UniTask<Result> Do()
        {
            var length = this.loadingTasks.Length;
            UniTask<Result>[] tasks = new UniTask<Result>[length];

            for (int i = 0; i < length; i++)
            {
                UniTask<Result> task = this.loadingTasks[i].Do();
                tasks[i] = task;
            }

            Result[] results = await UniTask.WhenAll(tasks);

            return new Result
            {
                success = results.All(it => it.success)
            };
        }
    }
}