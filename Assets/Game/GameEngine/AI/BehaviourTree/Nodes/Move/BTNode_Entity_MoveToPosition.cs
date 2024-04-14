using System;
using AI.Blackboards;
using AI.BTree;
using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.AI
{
    [Serializable]
    public sealed class BTNode_Entity_MoveToPosition : BehaviourNode
    {
        private readonly Agent_Entity_MoveToPosition moveAgent = new();

        private string unitKey;

        private string movePositionKey;

        private IBlackboard blackboard;
        
        public void ConstructBlackboardKeys(string unitKey, string movePositionKey)
        {
            this.unitKey = unitKey;
            this.movePositionKey = movePositionKey;
        }

        public void ConstructBlackboard(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void ConstructStoppingDistance(float stoppingDistance)
        {
            this.moveAgent.SetStoppingDistance(stoppingDistance);
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity entity))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.movePositionKey, out Vector3 targetPosition))
            {
                this.Return(false);
                return;
            }

            this.moveAgent.OnTargetReached += this.OnTargetReached;
            this.moveAgent.SetMovingEntity(entity);
            this.moveAgent.SetTarget(targetPosition);
            this.moveAgent.Play();
        }

        private void OnTargetReached(bool isReached)
        {
            if (isReached)
            {
                this.Return(true);
            }
        }

        protected override void OnDispose()
        {
            this.moveAgent.OnTargetReached -= this.OnTargetReached;
            this.moveAgent.Stop();
        }
    }
}