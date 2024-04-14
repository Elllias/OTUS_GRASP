using System.Collections;
using Entities;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class HealingPoint : MonoEntityStd
    {
        [Space]
        [SerializeField]
        public bool isActive;

        [SerializeField]
        private GameObject visual;

        private void OnTriggerEnter(Collider other)
        {
            if (!this.isActive)
            {
                return;
            }
            
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out IComponent_AddHitPoints hpComponent))
            {
                Debug.Log("HP RESTORED!");
                hpComponent.AddHitPoints(10);
            }

            this.StartCoroutine(this.Countdown());
        }

        private IEnumerator Countdown()
        {
            this.isActive = false;
            visual.SetActive(false);
            Debug.Log("TRIGGER INACTIVE");
            yield return new WaitForSeconds(5.0f);
            Debug.Log("TRIGGER ACTIVE");
            this.isActive = true;
            visual.SetActive(true);
        }
    }
}