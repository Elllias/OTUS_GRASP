using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Hit : IComponent_Hit
    {
        private readonly IEmitter eventReceiver;

        public Component_Hit(IEmitter eventReceiver)
        {
            this.eventReceiver = eventReceiver;
        }

        public void Hit()
        {
            this.eventReceiver.Call();
        }
    }
}