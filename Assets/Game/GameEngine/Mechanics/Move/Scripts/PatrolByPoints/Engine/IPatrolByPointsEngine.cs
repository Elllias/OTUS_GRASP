using System;

namespace Game.GameEngine.Mechanics
{
    public interface IPatrolByPointsEngine
    {
        event Action<PatrolByPointsOperation> OnPatrolStarted;

        event Action<PatrolByPointsOperation> OnPatrolStopped;

        bool IsPatrol { get;  }

        PatrolByPointsOperation CurrentOperation { get; }

        bool CanStartPatrol(PatrolByPointsOperation operation);

        void StartPatrol(PatrolByPointsOperation operation);

        void StopPatrol();
    }
}