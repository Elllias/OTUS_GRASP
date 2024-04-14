using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class IntEventReceiver : MonoBehaviour
    {
        public event Action<int> OnEvent;

        [Button]
        public void Call(int value)
        {
            this.OnEvent?.Invoke(value);
        }
    }
}