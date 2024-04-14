using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface ITransformEngine
    {
        Vector3 WorldPosition { get; }
 
        Quaternion WorldRotation { get; }
        
        void SetPosiiton(Vector3 position);

        void MovePosition(Vector3 vector);

        bool IsDistanceReached(Vector3 targetPosition, float minDistance);

        void SetRotation(Quaternion rotation);

        void LookAtPosition(Vector3 targetPosition);

        void LookInDirection(Vector3 direction);

        void RotateTowardsAtPosition(Vector3 targetPosition, float speed, float deltaTime);

        void RotateTowardsInDirection(Vector3 direction, float speed, float deltaTime);
    }
}