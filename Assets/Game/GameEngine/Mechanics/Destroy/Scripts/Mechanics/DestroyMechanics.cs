using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public abstract class DestroyMechanics :
        IEnableListener,
        IDisableListener
    {
        public IEmitter<DestroyArgs> emitter;

        void IEnableListener.OnEnable()
        {
            this.emitter.OnEvent += this.Destroy;
        }

        void IDisableListener.OnDisable()
        {
            this.emitter.OnEvent -= this.Destroy;
        }

        protected abstract void Destroy(DestroyArgs destroyArgs);
    }
}