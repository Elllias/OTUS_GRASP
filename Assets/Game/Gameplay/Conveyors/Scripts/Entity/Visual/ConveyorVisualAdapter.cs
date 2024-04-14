using Elementary;
using Declarative;
using UnityEngine;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorVisualAdapter :
        IEnableListener,
        IDisableListener
    {
        private ITimer workTimer;

        private ConveyorVisual conveyor;

        public void Construct(ITimer workTimer, ConveyorVisual conveyor)
        {
            this.workTimer = workTimer;
            this.conveyor = conveyor;
        }

        void IEnableListener.OnEnable()
        {
            this.workTimer.OnStarted += this.OnStartWork;
            this.workTimer.OnFinished += this.OnFinishWork;
        }

        void IDisableListener.OnDisable()
        {
            this.workTimer.OnStarted -= this.OnStartWork;
            this.workTimer.OnFinished -= this.OnFinishWork;
        }

        private void OnStartWork()
        {
            this.conveyor.Play();
        }

        private void OnFinishWork()
        {
            this.conveyor.Stop();
        }
    }
}