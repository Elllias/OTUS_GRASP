using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics.Money.Scripts;
using UnityEngine;

namespace Lessons.AI.Lesson_GOAP
{
    public sealed class MarketPoint : MonoEntityStd
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEntity entity) &&
                entity.TryGet(out IComponent_ResourceSource resourceSource) && 
                entity.TryGet(out IComponent_EarnMoney moneyComponent))
            {
                Debug.Log("SELL RESOURCES");
                resourceSource.Clear();
                moneyComponent.EarnMoney(50);
            }
        }
    }
}