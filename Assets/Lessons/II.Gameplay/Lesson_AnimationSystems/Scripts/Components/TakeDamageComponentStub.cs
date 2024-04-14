using System;
using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    [Serializable]
    public sealed class TakeDamageComponentStub : ITakeDamageComponent
    {
        [SerializeField]
        private MonoEmitter takeDamageReceiver;
        
        public void TakeDamage(int damage)
        {
            Debug.Log($"Damage Taken {damage}");
            this.takeDamageReceiver.Call();
        }
    }
}