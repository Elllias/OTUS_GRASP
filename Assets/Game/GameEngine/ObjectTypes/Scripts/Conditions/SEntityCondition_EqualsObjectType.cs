using Entities;
using UnityEngine;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "Condition «Equals Object Type»",
        menuName = "GameEngine/Object Types/New Entity Condition «Equals Object Type»"
    )]
    public sealed class SEntityCondition_EqualsObjectType : ScriptableEntityCondition
    {
        [SerializeField]
        private ObjectType objectType;

        public override bool IsTrue(IEntity entity)
        {
            if (entity.TryGet(out IComponent_GetObjectType component))
            {
                return component.ObjectType == this.objectType;
            }

            Debug.LogWarning("Component «Get Object Type» is not found!");
            return default;
        }
    }
}