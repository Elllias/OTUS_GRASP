using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.GameEngine;
using Game.UI;
using UnityEngine;

namespace Lessons.Architecture.Loading
{
    [CreateAssetMenu(
        fileName = "LoadingTask_LoadPopups",
        menuName = "Lessons/Tasks/New LoadingTask_LoadPopups"
    )]
    public sealed class LoadingTask_LoadPopups : LoadingTask
    {
        public async override UniTask<Result> Do()
        {
            var popupCatalog = Resources.Load<PopupCatalog>(nameof(PopupCatalog));
            await popupCatalog.LoadAssets();

            return await Task.FromResult(new Result
            {
                success = true
            });
        }
    }
}