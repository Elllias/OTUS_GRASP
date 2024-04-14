using UnityEngine;

namespace Entities
{
    public abstract class ScriptableEntityCondition : ScriptableObject, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}