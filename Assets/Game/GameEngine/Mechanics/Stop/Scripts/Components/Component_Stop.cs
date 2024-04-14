using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Stop : IComponent_Stop
    {
        private readonly IEmitter stopEmitter;

        public Component_Stop(IEmitter stopEmitter)
        {
            this.stopEmitter = stopEmitter;
        }

        public void Stop()
        {
            this.stopEmitter.Call();
        }
    }
}