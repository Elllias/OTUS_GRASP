using AI.Agents;
using Entities;
using Game.GameEngine.Mechanics;
using Polygons;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class Agent_Entity_FollowEntityByPolygon : Agent_FollowPositionByArea
    {
        protected override Agent_MoveToTarget<Vector3> MoveAgent
        {
            get { return this.moveAgent; }
        }

        private readonly Agent_Entity_MoveToPosition moveAgent = new();
        
        private MonoPolygon surface;

        private IComponent_GetPosition followerComponent;

        private IComponent_GetPosition targetComponent;

        public void SetSurface(MonoPolygon polygon)
        {
            this.surface = polygon;
        }

        public void SetFollowingEntity(IEntity follower)
        {
            this.followerComponent = follower.Get<IComponent_GetPosition>();
            this.moveAgent.SetMovingEntity(follower);
        }

        public void SetTargetEntity(IEntity target)
        {
            this.targetComponent = target.Get<IComponent_GetPosition>();
        }

        public void SetIntermediateDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        protected override bool FindNextPosition(out Vector3 availablePosition)
        {
            var targetPosition = this.EvaluateTargetPosition();
            if (this.surface.IsPointInside(targetPosition))
            {
                availablePosition = targetPosition;
                return true;
            }

            if (this.surface.ClampPosition(targetPosition, out _, out var clampedPosition))
            {
                availablePosition = clampedPosition;
                return true;
            }
            
            availablePosition = default;
            return false;
        }

        protected override Vector3 EvaluateCurrentPosition()
        {
            return this.followerComponent.Position;
        }

        protected override Vector3 EvaluateTargetPosition()
        {
            return this.targetComponent.Position;
        }
    }
}