using System.Collections;
using CustomParticles;
using Game.GameEngine;
using Game.GameEngine.GameResources;
using Game.GameEngine.GUI;
using Game.UI;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class ResourcePanelAnimator_AddResources : MonoBehaviour, IGameConstructElement
    {
        [Space]
        [SerializeField]
        private ResourcePanel panel;

        [SerializeField]
        private ResourceInfoCatalog resourceCatalog;

        [Space]
        [SerializeField]
        private int maxParticleCount;

        [SerializeField]
        private float emissonPeriod;

        [SerializeField]
        private UIAnimations.FlySettings settings;

        private ParticlePool<ImageParticle> particlePool;

        private Transform worldViewport;

        private Camera worldCamera;

        private Camera uiCamera;

        public void PlayIncomeFromWorld(Vector3 startWorldPosition, ResourceType resourceType, int income)
        {
            this.StartCoroutine(this.PlayFromWorldRoutine(startWorldPosition, resourceType, income));
        }

        private IEnumerator PlayFromWorldRoutine(Vector3 startWorldPosition, ResourceType resourceType, int income)
        {
            if (!this.panel.IsItemShown(resourceType))
            {
                this.panel.ShowItem(resourceType);
                yield return new WaitForEndOfFrame(); //Wait for calc UI position    
            }

            var info = this.resourceCatalog.FindResource(resourceType);
            var icon = info.icon;

            var prevValue = this.panel.GetCurrentValue(resourceType);
            var newValue = prevValue + income;
            var particleIterator = new IntValueIterator(prevValue, newValue, this.maxParticleCount);

            var emissionPeriod = new WaitForSeconds(this.emissonPeriod);
            var endUIPosition = this.panel.GetIconCenter(resourceType);

            for (int i = 0, count = particleIterator.ParticleCount; i < count; i++)
            {
                var routine = this.PlayParticle(
                    startWorldPosition,
                    endUIPosition,
                    icon,
                    resourceType,
                    particleIterator
                );
                this.StartCoroutine(routine);
                yield return emissionPeriod;
            }
        }

        private IEnumerator PlayParticle(
            Vector3 startWorldPosition,
            Vector3 endUIPosiiton,
            Sprite icon,
            ResourceType resourceType,
            IntValueIterator particleIterator
        )
        {
            var particleObject = this.particlePool.Get(this.worldViewport);
            particleObject.SetIcon(icon);

            var particleTransform = particleObject.transform;
            particleTransform.position = CameraUtils.FromWorldToUIPosition(
                this.worldCamera,
                this.uiCamera,
                startWorldPosition
            );

            yield return UIAnimations.AnimateFlyRoutine(particleTransform, this.settings, endUIPosiiton);
            this.particlePool.Release(particleObject);

            if (particleIterator.NextValue(out var resourceCount))
            {
                this.panel.IncrementItem(resourceType, resourceCount);
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.particlePool = context.GetService<GUIParticlePoolService>().ImagePool;
            this.uiCamera = context.GetService<GUICameraService>().Camera;
            this.worldCamera = WorldCamera.Instance;
            this.worldViewport = context.GetService<GUIParticleViewportService>().WorldViewport;
        }
    }
}