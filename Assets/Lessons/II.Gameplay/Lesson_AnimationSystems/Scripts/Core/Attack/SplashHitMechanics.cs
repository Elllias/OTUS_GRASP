using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class SplashHitMechanics : MonoBehaviour
    {
        [SerializeField]
        private MonoEmitter hitReceiver;

        [SerializeField]
        private SplashDamageEngine damageEngine;

        private void OnEnable()
        {
            this.hitReceiver.OnEvent += this.OnHit;
        }

        private void OnDisable()
        {
            this.hitReceiver.OnEvent -= this.OnHit;
        }

        private void OnHit()
        {
            this.damageEngine.DealDamage();
        }
    }
}