using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Can Destroy»",
        menuName = "GameEngine/Mechanics/Destroy/New Entity Condition «Can Destroy»"
    )]
    public sealed class SEntityCondition_CanDestroy : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_CanDestroy component))
            {
                return component.CanDestroy();
            }
            
            Debug.LogWarning("Component «Can Destroy» is not found!");
            return default;
        }
    }
}