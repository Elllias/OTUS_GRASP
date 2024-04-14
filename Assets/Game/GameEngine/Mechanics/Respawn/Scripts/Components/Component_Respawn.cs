using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Respawn : IComponent_Respawn
    {
        private readonly IEmitter emitter;

        public Component_Respawn(IEmitter emitter)
        {
            this.emitter = emitter;
        }

        public void Respawn()
        {
            this.emitter.Call();
        }
    }
}