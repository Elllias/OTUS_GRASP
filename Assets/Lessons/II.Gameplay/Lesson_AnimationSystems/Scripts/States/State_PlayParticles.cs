using Elementary;
using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class State_PlayParticles : MonoState
    {
        [SerializeField]
        private ParticleSystem[] particles;

        public override void Enter()
        {
            for (int i = 0, count = this.particles.Length; i < count; i++)
            {
                var particleSystem = this.particles[i];
                particleSystem.Play(withChildren: true);
            }
        }

        public override void Exit()
        {
            for (int i = 0, count = this.particles.Length; i < count; i++)
            {
                var particleSystem = this.particles[i];
                particleSystem.Stop(withChildren: true);
            }
        }
    }
}