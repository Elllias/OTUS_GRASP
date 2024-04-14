using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public abstract class UDestroyMechanics : MonoBehaviour
    {
        [SerializeField]
        public DestroyEventReceiver eventReceiver;

        protected virtual void OnEnable()
        {
            this.eventReceiver.OnDestroy += this.OnDestroyEvent;
        }

        protected virtual void OnDisable()
        {
            this.eventReceiver.OnDestroy -= this.OnDestroyEvent;
        }

        protected abstract void OnDestroyEvent(DestroyArgs destroyArgs);
    }
}