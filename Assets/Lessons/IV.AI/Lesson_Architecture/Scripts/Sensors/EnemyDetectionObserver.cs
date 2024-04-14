using Elementary;
using Entities;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public sealed class EnemyDetectionObserver : ColliderDetectionObserver
    {
        [SerializeField]
        private AttackAgent attackAgent;

        protected override void OnCollidersUpdated(Collider[] buffer, int size)
        {
            if (size > 0 && this.attackAgent.Target == null)
            {
                var target = buffer[0].GetComponent<IEntity>();
                this.attackAgent.SetTarget(target);
                return;
            }

            if (size <= 0 && this.attackAgent.Target != null)
            {
                this.attackAgent.SetTarget(null);
            }
        }
    }
}