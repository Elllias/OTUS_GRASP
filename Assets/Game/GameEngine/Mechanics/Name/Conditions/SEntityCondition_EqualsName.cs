using Elementary;
using Entities;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [CreateAssetMenu(
        fileName = "Condition «Equals Name»",
        menuName = "GameEngine/Mechanics/Name/New Entity Condition «Equals Name»"
    )]
    public sealed class SEntityCondition_EqualsName : ScriptableEntityCondition
    {
        [SerializeField]
        private StringAdapter expectedName; 
    
        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_GetName component))
            {
                return this.expectedName.Current == component.Name;
            }

            Debug.LogWarning("Component «Get Name» is not found!");
            return default;
        }
    }
}