using System;

namespace Modules.AI
{
    public interface IAgent
    {
        event Action OnStarted;

        event Action OnStopped;

        bool IsPlaying { get; }

        void Play();
        
        void Stop();
    }
}