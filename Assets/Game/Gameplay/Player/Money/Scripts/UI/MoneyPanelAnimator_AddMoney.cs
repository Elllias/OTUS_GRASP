using System.Collections;
using CustomParticles;
using Game.GameEngine;
using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class MoneyPanelAnimator_AddMoney : MonoBehaviour, IGameConstructElement
    {
        [Space]
        [SerializeField]
        private MoneyPanel panel;

        [SerializeField]
        private Sprite moneyIcon;

        [Space]
        [SerializeField]
        private int maxParticleCount;

        [SerializeField]
        private float emissonPeriod;

        [SerializeField]
        private UIAnimations.FlySettings settings;

        private ParticlePool<ImageParticle> particlePool;

        private Transform worldViewport;

        private Transform overlayViewport;

        private Camera worldCamera;

        private Camera uiCamera;

        public void PlayIncomeFromUI(Vector3 startUIPosition, int income)
        {
            this.StartCoroutine(this.PlayFromUIRoutine(startUIPosition, income));
        }

        private IEnumerator PlayFromUIRoutine(Vector3 startUIPosition, int income)
        {
            var prevValue = this.panel.Money;
            var newValue = prevValue + income;
            var particleIterator = new IntValueIterator(prevValue, newValue, this.maxParticleCount);

            var endUIPosition = this.panel.GetIconPosition();
            var emissionPeriod = new WaitForSeconds(this.emissonPeriod);

            for (int i = 0, count = particleIterator.ParticleCount; i < count; i++)
            {
                this.StartCoroutine(this.PlayParticleFromUI(startUIPosition, endUIPosition, particleIterator));
                yield return emissionPeriod;
            }
        }

        private IEnumerator PlayParticleFromUI(Vector3 startUIPosition, Vector3 endUIPosition, IntValueIterator particleIterator)
        {
            var particleObject = this.particlePool.Get(this.overlayViewport);
            particleObject.SetIcon(this.moneyIcon);

            var particleTransform = particleObject.transform;
            particleTransform.position = startUIPosition;
            yield return UIAnimations.AnimateFlyRoutine(particleTransform, this.settings, endUIPosition);
            this.particlePool.Release(particleObject);

            if (particleIterator.NextValue(out var resourceCount))
            {
                this.panel.IncrementMoney(resourceCount);
            }
        }

        public void PlayIncomeFromWorld(Vector3 startWorldPosition, int income)
        {
            this.StartCoroutine(this.PlayFromWorldRoutine(startWorldPosition, income));
        }

        private IEnumerator PlayFromWorldRoutine(Vector3 startWorldPosition, int income)
        {
            var prevValue = this.panel.Money;
            var newValue = prevValue + income;
            var particleIterator = new IntValueIterator(prevValue, newValue, this.maxParticleCount);

            var endUIPosition = this.panel.GetIconPosition();
            var emissionPeriod = new WaitForSeconds(this.emissonPeriod);

            for (int i = 0, count = particleIterator.ParticleCount; i < count; i++)
            {
                this.StartCoroutine(this.PlayParticleFromWorld(startWorldPosition, endUIPosition, particleIterator));
                yield return emissionPeriod;
            }
        }

        private IEnumerator PlayParticleFromWorld(
            Vector3 startWorldPosition,
            Vector3 endUIPosiiton,
            IntValueIterator particleIterator
        )
        {
            var particleObject = this.particlePool.Get(this.worldViewport);
            particleObject.SetIcon(this.moneyIcon);

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
                this.panel.IncrementMoney(resourceCount);
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.particlePool = context.GetService<GUIParticlePoolService>().ImagePool;
            this.uiCamera = context.GetService<GUICameraService>().Camera;
            this.worldCamera = WorldCamera.Instance;
            
            var viewportService = context.GetService<GUIParticleViewportService>();
            this.worldViewport = viewportService.WorldViewport;
            this.overlayViewport = viewportService.OverlayViewport;
        }
    }
}