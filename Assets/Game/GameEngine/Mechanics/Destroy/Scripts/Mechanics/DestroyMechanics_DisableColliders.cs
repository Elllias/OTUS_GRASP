using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [Serializable]
    public sealed class DestroyMechanics_DisableColliders : DestroyMechanics
    {
        [SerializeField, Space]
        public Collider[] colliders;

        protected override void Destroy(DestroyArgs destroyArgs)
        {
            for (int i = 0, count = this.colliders.Length; i < count; i++)
            {
                var collider = this.colliders[i];
                collider.enabled = false;
            }
        }
    }
}