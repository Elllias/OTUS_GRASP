using System;

namespace Game.App
{
    public interface ILoadingTask
    {
        void Do(Action<LoadingResult> callback);
    }
}


