using System.Collections;
using Entities;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP2
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class Bullet : MonoBehaviour
    {
        private void Awake()
        {
            var rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.velocity = this.transform.forward * 7.5f;
        }

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(3.0f);
            Destroy(this.gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity) ||
                !entity.TryGet(out IComponent_TakeDamage takeDamageComponent))
            {
                return;
            }

            takeDamageComponent.TakeDamage(new TakeDamageArgs
            {
                damage = 1,
                reason = TakeDamageReason.BULLET
            });
                
            Destroy(this.gameObject);
        }
    }
}