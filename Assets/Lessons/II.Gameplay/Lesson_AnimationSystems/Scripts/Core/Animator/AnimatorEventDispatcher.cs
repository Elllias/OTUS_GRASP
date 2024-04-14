using System;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class AnimatorEventDispatcher : MonoBehaviour
    {
        public event Action<string> OnEventReceived;

        public void ReceiveEvent(string key)
        {
            this.OnEventReceived?.Invoke(key);
        }
    }
}