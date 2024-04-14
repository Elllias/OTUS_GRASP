using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IMoveToPositionMotor
    {
        event Action<Vector3> OnMoveStarted;

        event Action<Vector3> OnMoveStopped;

        bool IsMove { get; }

        Vector3 TargetPosition { get; }

        bool CanStartMove(Vector3 operation);

        void StartMove(Vector3 operation);

        void StopMove();
    }
}