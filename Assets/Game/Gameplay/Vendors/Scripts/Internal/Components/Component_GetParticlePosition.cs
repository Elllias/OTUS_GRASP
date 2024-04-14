using UnityEngine;

namespace Game.Gameplay.Vendors
{
    public sealed class Component_GetParticlePosition : IComponent_GetParticlePosition
    {
        public Vector3 Position
        {
            get { return this.emissionPoint.position; }
        }

        private readonly Transform emissionPoint;

        public Component_GetParticlePosition(Transform emissionPoint)
        {
            this.emissionPoint = emissionPoint;
        }
    }
}