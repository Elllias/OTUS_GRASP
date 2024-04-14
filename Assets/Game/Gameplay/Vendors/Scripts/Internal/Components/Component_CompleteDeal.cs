using Elementary;

namespace Game.Gameplay.Vendors
{
    public sealed class Component_CompleteDeal : IComponent_CompleteDeal
    {
        private readonly IEmitter emitter;

        public Component_CompleteDeal(IEmitter emitter)
        {
            this.emitter = emitter;
        }

        public void NotifyAboutCompleted()
        {
            this.emitter.Call();
        }
    }
}