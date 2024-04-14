using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public abstract class AbstractEventObserver : MonoBehaviour
    {
        [SerializeField]
        private MonoEmitter eventReceiver;

        private void OnEnable()
        {
            this.eventReceiver.OnEvent += this.OnEvent;
        }

        private void OnDisable()
        {
            this.eventReceiver.OnEvent += this.OnEvent;
        }

        protected abstract void OnEvent();
    }
}