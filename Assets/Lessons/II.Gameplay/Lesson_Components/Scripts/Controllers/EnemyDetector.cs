using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    //Dummy
    public sealed class EnemyDetector : MonoBehaviour
    {
        public event Action<Entity> OnEnemyDetected;
        
        [Button]
        public void Call(Entity obj)
        {
            OnEnemyDetected?.Invoke(obj);
        }
    }
}