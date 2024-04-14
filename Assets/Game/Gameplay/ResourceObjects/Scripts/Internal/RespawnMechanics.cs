using Elementary;
using Declarative;

namespace Game.Gameplay.ResourceObjects
{
    public sealed class RespawnMechanics :
        IEnableListener,
        IDisableListener
    {
        private readonly Countdown countdown = new();
        
        private IEmitter destroyEvent;

        private IEmitter respawnEvent;

        public void ConstructDuration(float duration)
        {
            this.countdown.Duration = duration;
        }

        public void ConstructRespawnEvent(IEmitter respawnEvent)
        {
            this.respawnEvent = respawnEvent;
        }

        public void ConstructDestroyEvent(IEmitter destroyEvent)
        {
            this.destroyEvent = destroyEvent;
        }

        void IEnableListener.OnEnable()
        {
            this.destroyEvent.OnEvent += this.OnDeactivate;
            this.countdown.OnEnded += this.OnActivate;
        }

        void IDisableListener.OnDisable()
        {
            this.destroyEvent.OnEvent -= this.OnDeactivate;
            this.countdown.OnEnded -= this.OnActivate;
        }

        private void OnDeactivate()
        {
            this.countdown.ResetTime();
            this.countdown.Play();
        }

        private void OnActivate()
        {
            this.respawnEvent.Call();
        }
    }
}