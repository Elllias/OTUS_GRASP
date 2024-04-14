using Elementary;

namespace Game.GameEngine.Mechanics
{
    public sealed class Component_Collect_Emitter : IComponent_Collect
    {
        private readonly IEmitter emitter;

        public Component_Collect_Emitter(IEmitter emitter)
        {
            this.emitter = emitter;
        }

        public void Collect()
        {
            this.emitter.Call();
        }
    }
}