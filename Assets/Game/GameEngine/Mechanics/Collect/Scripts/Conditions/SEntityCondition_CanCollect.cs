using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Can Collect»",
        menuName = "GameEngine/Mechanics/Collect/New Entity Condition «Can Collect»"
    )]
    public sealed class SEntityCondition_CanCollect : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_CanCollect component))
            {
                return component.CanCollect;
            }

            Debug.LogWarning("Component «Can Collect» is not found!");
            return default;
        }
    }
}