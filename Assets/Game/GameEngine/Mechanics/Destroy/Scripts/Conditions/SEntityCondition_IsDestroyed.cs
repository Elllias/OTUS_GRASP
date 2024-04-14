using Entities;
using Game.GameEngine;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Is Destroyed»",
        menuName = "GameEngine/Mechanics/Destroy/New Entity Condition «Is Destroyed»"
    )]
    public sealed class SEntityCondition_IsDestroyed : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_IsDestroyed component))
            {
                return component.IsDestroyed;
            }

            Debug.LogWarning("Component «Is Destroyed» is not found!");
            return default;
        }
    }
}