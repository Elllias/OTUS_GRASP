using UnityEngine;

namespace Lessons.Gameplay.AnimationSystems
{
    public sealed class EventObserver_PlayParticles : AbstractEventObserver
    {
        [SerializeField]
        private ParticleSystem[] particles;

        protected override void OnEvent()
        {
            foreach (var particle in this.particles)
            {
                particle.Play(withChildren: true);
            }
        }
    }
    
}