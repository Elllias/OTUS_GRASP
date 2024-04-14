using AI.Blackboards;
using AI.BTree;
using Entities;
using Polygons;
using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class BTNode_Entity_FollowEntityByPolygon : BehaviourNode
    {
        private readonly Agent_Entity_FollowEntityByPolygon followAgent = new();

        private string unitKey;

        private string targetKey;

        private string surfaceKey;

        private IBlackboard blackboard;
        
        public BTNode_Entity_FollowEntityByPolygon()
        {
            this.followAgent.SetCalculatePathPeriod(new WaitForFixedUpdate());
            this.followAgent.SetCheckTargetReachedPeriod(null);
        }

        public void ConstructBlackboard(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void ConstructBlackboardKeys(string unitKey, string targetKey, string surfaceKey)
        {
            this.unitKey = unitKey;
            this.targetKey = targetKey;
            this.surfaceKey = surfaceKey;
        }

        public void ConstructStoppingDistance(float distance)
        {
            this.followAgent.SetStoppingDistance(distance);
        }

        public void ConstructIntermediateDistance(float distance)
        {
            this.followAgent.SetIntermediateDistance(distance);
        }

        protected override void Run()
        {
            if (!this.blackboard.TryGetVariable(this.unitKey, out IEntity unit))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.targetKey, out IEntity target))
            {
                this.Return(false);
                return;
            }

            if (!this.blackboard.TryGetVariable(this.surfaceKey, out MonoPolygon polygon))
            {
                this.Return(false);
                return;
            }

            this.followAgent.OnTargetReached += this.OnTargetReached;
            this.followAgent.SetSurface(polygon);
            this.followAgent.SetTargetEntity(target);
            this.followAgent.SetFollowingEntity(unit);
            this.followAgent.Play();
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
            this.followAgent.Stop();
            this.followAgent.OnTargetReached -= this.OnTargetReached;
        }
    }
}