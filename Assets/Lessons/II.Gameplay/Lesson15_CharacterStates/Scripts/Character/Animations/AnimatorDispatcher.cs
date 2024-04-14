using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Lessons.Character.Animations
{
    internal sealed class AnimatorDispatcher : MonoBehaviour
    {
        internal event Action<string> OnMessageReceived; 

        [UsedImplicitly]
        //Called from animator: don't remove!
        public void ReceiveString(string message)
        {
            this.OnMessageReceived?.Invoke(message);
        }
    }
}