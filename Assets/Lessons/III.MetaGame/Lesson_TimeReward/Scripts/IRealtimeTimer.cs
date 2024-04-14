using System;

namespace Lessons.MetaGame
{
    public interface IRealtimeTimer
    {
        event Action<IRealtimeTimer> OnStarted;
        
        string Id { get; }
        
        void Synchronize(float offlineSeconds);
    }
}