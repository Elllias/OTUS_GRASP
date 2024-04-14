using Elementary;
using Entities;
using UnityEngine;
using static Lessons.AI.HierarchicalStateMachine.BlackboardKeys;

namespace Lessons.AI.HierarchicalStateMachine
{
    public sealed class EnemyDetectionObserver : ColliderDetectionObserver
    {
        [SerializeField]
        private Blackboard blackboard;

        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (!this.blackboard.HasVariable(ENEMY))
            {
                if (this.FindTarget(buffer, size, out IEntity enemy))
                {
                    this.blackboard.SetVariable(ENEMY, enemy);
                }
            }
            else
            {
                IEntity enemy = this.blackboard.GetVariable<IEntity>(ENEMY);
                if (!this.IsTargetExists(buffer, size, enemy))
                {
                    this.blackboard.RemoveVariable(ENEMY);
                }
            }
        }

        private bool FindTarget(Collider[] buffer, int size, out IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.TryGetComponent(out IEntity entity))
                {
                    target = entity;
                    return true;
                }
            }

            target = default;
            return false;
        }

        private bool IsTargetExists(Collider[] buffer, int size, IEntity target)
        {
            for (var i = 0; i < size; i++)
            {
                var collder = buffer[i];
                if (collder.TryGetComponent(out IEntity entity) && target == entity)
                {
                    return true;
                }
            }

            return false;
        }
    }
}