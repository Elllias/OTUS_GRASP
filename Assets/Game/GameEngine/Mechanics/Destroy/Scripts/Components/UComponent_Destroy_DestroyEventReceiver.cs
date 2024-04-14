using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Destroy/Component «Destroy» (Destroy Event Receiver)")]
    public sealed class UComponent_Destroy_DestroyEventReceiver : MonoBehaviour,
        IComponent_Destroy<DestroyArgs>,
        IComponent_OnDestroyed<DestroyArgs>
    {
        public event Action<DestroyArgs> OnDestroyed
        {
            add { this.eventReceiver.OnDestroy += value; }
            remove { this.eventReceiver.OnDestroy -= value; }
        }

        [SerializeField]
        private DestroyEventReceiver eventReceiver;

        public void Destroy(DestroyArgs args)
        {
            this.eventReceiver.Call(args);
        }
    }
}