using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class Vector3EventReceiver : MonoBehaviour
    {
        public event Action<Vector3> OnEvent;

        [Button]
        public void Call(Vector3 vector)
        {
            this.OnEvent?.Invoke(vector);
        }
    }
}