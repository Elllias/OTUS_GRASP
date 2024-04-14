using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class EntityEventReceiver : MonoBehaviour
    {
        public event Action<Entity> OnEvent;

        [Button]
        public void Call(Entity entity)
        {
            this.OnEvent?.Invoke(entity);
        }
    }
}