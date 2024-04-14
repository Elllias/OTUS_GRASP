using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Is Moving»",
        menuName = "GameEngine/Mechanics/Move/New Entity Condition «Is Moving»"
    )]
    public sealed class SEntityCondition_IsMoving : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_IsMoving component))
            {
                return component.IsMoving;
            }

            Debug.LogWarning("Component «Is Moving» is not found!");
            return default;
        }
    }
}