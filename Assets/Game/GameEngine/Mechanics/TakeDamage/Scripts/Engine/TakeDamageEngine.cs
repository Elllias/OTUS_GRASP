using System;
using Elementary;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class TakeDamageEngine : Emitter<TakeDamageArgs>
    {
        private IHitPoints hitPointsEngine;

        private IEmitter<DestroyArgs> destroyReceiver;

        public void Construct(IHitPoints hitPointsEngine, IEmitter<DestroyArgs> destroyReceiver)
        {
            this.hitPointsEngine = hitPointsEngine;
            this.destroyReceiver = destroyReceiver;
        }
        
        public override void Call(TakeDamageArgs damageArgs)
        {
            if (damageArgs.damage <= 0)
            {
                return;
            }
        
            if (this.hitPointsEngine.Current <= 0)
            {
                return;
            }

            this.hitPointsEngine.Current -= damageArgs.damage;
            base.Call(damageArgs);

            if (this.hitPointsEngine.Current <= 0)
            {
                var destroyEvent = MechanicsUtils.ConvertToDestroyEvent(damageArgs);
                this.destroyReceiver.Call(destroyEvent);
            }
        }
    }
}