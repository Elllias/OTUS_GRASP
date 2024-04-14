using System;
using Services;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_InstallApplicationServices : ILoadingTask
    {
        public void Do(Action<LoadingResult> callback)
        {
            var serviceInstaller = GameObject.FindObjectOfType<ServiceInstaller>();
            serviceInstaller.Install();
            callback.Invoke(LoadingResult.Success());
        }
    }
}