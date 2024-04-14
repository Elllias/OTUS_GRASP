using System;
using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    [Serializable]
    public sealed class AttackComponent : IAttackComponent
    {
        [SerializeField]
        private MonoEmitter attackReceiver;

        public void Attack()
        {
            this.attackReceiver.Call();
        }
    }
}