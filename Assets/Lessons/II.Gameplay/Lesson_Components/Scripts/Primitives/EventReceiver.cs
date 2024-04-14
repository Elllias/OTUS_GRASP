using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.Components
{
    public sealed class EventReceiver : MonoBehaviour
    {
        public event Action OnEvent;

        [Button]
        public void Call()
        {
            Debug.Log($"Event {name} was received!");
            this.OnEvent?.Invoke();
        }
    }
}