using AI.Blackboards;
using AI.BTree;
using Entities;

namespace Game.GameEngine.AI
{
    public sealed class BTNode_Entity_FollowEntity : BehaviourNode
    {
        private readonly Agent_Entity_FollowEntity followAgent = new();

        private string unitKey;

        private string targetKey;

        private string stoppingDistanceKey;

        private IBlackboard blackboard;

        public void ConstructBlackboard(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public void ConstructKeys(
            string unitKey,
            string targetKey,
            string stoppingDistanceKey 
        )
        {
            this.unitKey = unitKey;
            this.targetKey = targetKey;
            this.stoppingDistanceKey = stoppingDistanceKey;
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

            if (!this.blackboard.TryGetVariable(this.stoppingDistanceKey, out float stoppingDistance))
            {
                this.Return(false);
                return;
            }

            this.followAgent.OnTargetReached += this.OnTargetReached;
            this.followAgent.SetFollowingEntity(unit);
            this.followAgent.SetTargetEntity(target);
            this.followAgent.SetStoppingDistance(stoppingDistance);
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
            this.followAgent.OnTargetReached -= this.OnTargetReached;
            this.followAgent.Stop();
        }
    }
}