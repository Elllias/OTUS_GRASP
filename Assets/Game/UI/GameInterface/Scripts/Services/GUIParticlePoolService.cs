using CustomParticles;
using UnityEngine;

namespace Game.GameEngine.GUI
{
    public sealed class GUIParticlePoolService : MonoBehaviour
    {
        public ParticlePool<RectTransform> PointPool
        {
            get { return this.pointParticlePool; }
        }

        public ParticlePool<ImageParticle> ImagePool
        {
            get { return this.imageParticlePool; }
        }

        [SerializeField]
        private ParticlePool<RectTransform> pointParticlePool;

        [SerializeField]
        private ParticlePool<ImageParticle> imageParticlePool;
    }
}