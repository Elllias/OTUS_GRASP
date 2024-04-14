using System;
using Lessons.Gameplay.Interaction;
using Lessons.Utils;

namespace Lessons.StateMachines.States
{
    [Serializable]
    public sealed class GatheringTimerState : UpdateState
    {
        private float currentTime;

        private AtomicVariable<float> duration;
        private IAtomicProcess<GatherResourceCommand> process;

        public void Construct(
            AtomicVariable<float> duration,
            IAtomicProcess<GatherResourceCommand> process
        )
        {
            this.duration = duration;
            this.process = process;
        }

        protected override void OnEnter()
        {
            this.currentTime = 0.0f;
        }

        protected override void OnUpdate(float deltaTime)
        {
            this.currentTime += deltaTime;
            if (this.currentTime >= this.duration)
            {
                this.process.State.Complete();
                this.process.Stop();
            }
        }
    }
}