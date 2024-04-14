using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/TakeDamage/Take Damage Engine")]
    public sealed class UTakeDamageEngine : MonoBehaviour
    {
        public event Action<TakeDamageArgs> OnDamageTaken;

        [SerializeField]
        private UHitPoints hitPointsEngine;

        [SerializeField]
        private DestroyEventReceiver destroyReceiver;

        [Button]
        [GUIColor(0, 1, 0)]
        public void TakeDamage(TakeDamageArgs damageArgs)
        {
            if (this.hitPointsEngine.Current <= 0)
            {
                return;
            }

            this.hitPointsEngine.Current -= damageArgs.damage;
            this.OnDamageTaken?.Invoke(damageArgs);

            if (this.hitPointsEngine.Current <= 0)
            {
                var destroyEvent = MechanicsUtils.ConvertToDestroyEvent(damageArgs);
                this.destroyReceiver.Call(destroyEvent);
            }
        }
    }
}