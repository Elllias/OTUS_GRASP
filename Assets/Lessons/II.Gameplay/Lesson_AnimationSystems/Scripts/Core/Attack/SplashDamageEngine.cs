using System;
using Elementary;
using Entities;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class SplashDamageEngine : MonoBehaviour
    {
        [Space]
        [SerializeField]
        private Transform centerPoint;

        [SerializeField]
        private float radius;

        [Space]
        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal;

        [SerializeField]
        private int bufferCapacity = 4;

        private Collider[] buffer;

        [Space]
        [SerializeField]
        private IntAdapter damage;

        private void Awake()
        {
            this.buffer = new Collider[this.bufferCapacity];
        }

        public void DealDamage()
        {
            var damage = this.damage.Current;

            var bufferSize = this.OverlapColliders();
            for (var i = 0; i < bufferSize; i++)
            {
                var target = this.buffer[i];
                if (target.TryGetComponent(out IEntity entity) &&
                    entity.TryGet(out ITakeDamageComponent takeDamageComponent))
                {
                    takeDamageComponent.TakeDamage(damage);
                }
            }
        }

        private int OverlapColliders()
        {
            Array.Clear(this.buffer, 0, this.buffer.Length);

            var bufferSize = Physics.OverlapSphereNonAlloc(
                position: this.centerPoint.position,
                radius: this.radius,
                results: this.buffer,
                layerMask: this.layerMask,
                queryTriggerInteraction: this.triggerInteraction
            );
            return bufferSize;
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            try
            {
                var prevColor = Gizmos.color;
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(this.centerPoint.position, this.radius);
                Gizmos.color = prevColor;
            }
            catch (Exception)
            {
            }
        }
#endif
    }
}