using Entities;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class BeerPoint : MonoEntityStd
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) && entity.TryGet(out IComponent_SpendMoney component))
            {
                Debug.Log("BUY BEER");
                component.SpendMoney(100);
            }
        }
    }
}