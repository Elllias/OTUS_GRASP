using AI.Agents;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class Agent_Entity_FollowEntityByNavMesh : Agent_FollowTargetByNavMesh
    {
        protected override Agent_MoveToTarget<Vector3> MoveAgent
        {
            get { return this.moveAgent; }
        }

        private readonly Agent_Entity_MoveToPosition moveAgent = new();

        private IComponent_GetPosition followerComponent;

        private IComponent_GetPosition targetComponent;

        public void SetFollowingEntity(IEntity follower)
        {
            this.followerComponent = follower.Get<IComponent_GetPosition>();
            this.moveAgent.SetMovingEntity(follower);
        }

        public void SetTargetEntity(IEntity target)
        {
            this.targetComponent = target.Get<IComponent_GetPosition>();
        }

        public void SetMinPointDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
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