using AI.Tasks;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class Task_Entity_MoveToPosition : AITask_MoveToTarget<Vector3>
    {
        private IComponent_GetPosition positionComponent;

        private IComponent_MoveInDirection moveComponent;

        private Vector3 targetPosition;

        private float sqrStoppingDistance;
        
        public void SetStoppingDistance(float stoppingDistance)
        {
            this.sqrStoppingDistance = stoppingDistance * stoppingDistance;
        }

        public void SetMovingEntity(IEntity unit)
        {
            this.positionComponent = unit.Get<IComponent_GetPosition>();
            this.moveComponent = unit.Get<IComponent_MoveInDirection>();
        }

        protected override bool CheckTargetReached(Vector3 target)
        {
            var moveVector = this.EvaluateMoveVector(target);
            return moveVector.sqrMagnitude <= this.sqrStoppingDistance;
        }

        protected override void MoveToTarget(Vector3 target)
        {
            var moveVector = this.EvaluateMoveVector(target);
            this.moveComponent.Move(moveVector.normalized);
        }
        
        private Vector3 EvaluateMoveVector(Vector3 targetPosition)
        {
            var currentPosition = this.positionComponent.Position;
            var moveVector = targetPosition - currentPosition;
            moveVector.y = 0;
            return moveVector;
        }
    }
}