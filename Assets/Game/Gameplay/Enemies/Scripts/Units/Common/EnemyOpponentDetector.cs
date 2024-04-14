using AI.Blackboards;
using Entities;
using Game.GameEngine.Mechanics;

namespace Game.Gameplay.Enemies
{
    public sealed class EnemyOpponentDetector : ColliderDetectionHandler_TargetEntity
    {
        private readonly IBlackboard blackboard;

        private readonly string targetKey;

        public EnemyOpponentDetector(
            IBlackboard blackboard,
            string targetKey,
            ScriptableEntityCondition[] detectConditions
        )
        {
            this.blackboard = blackboard;
            this.targetKey = targetKey;
            this.conditions = detectConditions;
        }

        protected override void ProcessTarget(bool targetFound, IEntity target)
        {
            if (targetFound && !this.blackboard.HasVariable(this.targetKey))
            {
                this.blackboard.AddVariable(this.targetKey, target);
                return;
            }

            if (!targetFound && this.blackboard.HasVariable(this.targetKey))
            {
                this.blackboard.RemoveVariable(this.targetKey);
            }
        }
    }
}