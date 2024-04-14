using UnityEngine;

namespace Entities
{
    public abstract class MonoEntityCondition : MonoBehaviour, IEntityCondition
    {
        public abstract bool IsTrue(IEntity entity);
    }
}