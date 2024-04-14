using Entities;
using Game.GameEngine;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Is Enable»",
        menuName = "GameEngine/Mechanics/Enable/New Entity Condition «Is Enable»"
    )]
    public class SEntityCondition_IsEnable : ScriptableEntityCondition
    {
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_Enable component))
            {
                return component.IsEnable;
            }

            Debug.LogWarning("Component «Is Enable» is not found!");
            return default;
        }
    }
}