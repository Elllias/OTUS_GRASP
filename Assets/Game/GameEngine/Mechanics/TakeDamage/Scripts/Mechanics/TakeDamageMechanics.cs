using Elementary;
using Declarative;

namespace Game.GameEngine.Mechanics
{
    public abstract class TakeDamageMechanics : IEnableListener, IDisableListener
    {
        public IEmitter<TakeDamageArgs> emitter;

        void IEnableListener.OnEnable()
        {
            this.emitter.OnEvent += this.OnDamageTaken;
        }

        void IDisableListener.OnDisable()
        {
            this.emitter.OnEvent -= this.OnDamageTaken;
        }

        protected abstract void OnDamageTaken(TakeDamageArgs damageArgs);
    }
}