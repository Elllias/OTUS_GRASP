using System.Collections;
using System.Collections.Generic;
using CustomParticles;
using Game.GameEngine;
using Game.GameEngine.GUI;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class MoneyPanelAnimator_AddJumpedMoney : MonoBehaviour, 
        IGameConstructElement,
        IGameLateUpdateElement
    {
        [Space]
        [SerializeField]
        private MoneyPanel panel;
        
        [SerializeField]
        private Sprite moneyIcon;

        [Space]
        [SerializeField]
        private int maxParticleCount;

        [Header("Animation")]
        [SerializeField]
        private UIAnimations.JumpSettings[] jumps;

        [SerializeField]
        private UIAnimations.FlySettings settings;

        private ParticlePool<ImageParticle> iconParticlePool;

        private ParticlePool<RectTransform> pointParticlePool;

        private Transform worldViewport;

        private List<RectTransform> pointParticles;

        private List<RectTransform> pointParticlesCache;

        private List<ImageParticle> iconParticles;

        private List<ImageParticle> iconParticlesCache;

        private List<Vector3> startWorldPositions;

        private List<Vector3> startWorldPositionsCache;

        private List<Vector3> startUIPositions;

        private List<Vector3> startUIPositionsCache;

        private Camera worldCamera;

        private Camera uiCamera;

        public void PlayIncomeFromWorld(Vector3 startWorldPosition, int income)
        {
            var endUIPosition = this.panel.GetIconPosition();
            
            var prevValue = this.panel.Money;
            var newValue = prevValue + income;
            var particleIterator = new IntValueIterator(prevValue, newValue, this.maxParticleCount);
            var particleCount = particleIterator.ParticleCount;

            var currentJumpAngle = 0.0f;
            var deltaJumpAngle = -360 / particleCount;

            for (var i = 0; i < particleCount; i++)
            {
                var jumpAngle = currentJumpAngle + Random.Range(-15.0f, 15.0f);
                var routine = this.PlayParticle(
                    startWorldPosition,
                    endUIPosition,
                    jumpAngle,
                    particleIterator
                );
                this.StartCoroutine(routine);

                currentJumpAngle += deltaJumpAngle;
            }
        }
        
        private IEnumerator PlayParticle(
            Vector3 startWorldPosition,
            Vector3 endUIPosiiton,
            float angle,
            IntValueIterator particleIterator
        )
        {
            var iconParticle = this.iconParticlePool.Get(this.worldViewport);
            iconParticle.SetIcon(this.moneyIcon);
            this.iconParticles.Add(iconParticle);

            var pointParticle = this.pointParticlePool.Get(this.worldViewport);
            this.pointParticles.Add(pointParticle);

            this.startWorldPositions.Add(startWorldPosition);
            var startUIPosition = CameraUtils.FromWorldToUIPosition(
                this.worldCamera,
                this.uiCamera,
                startWorldPosition
            );
            this.startUIPositions.Add(startUIPosition);
            pointParticle.position = startUIPosition;

            yield return UIAnimations.AnimateJumpRoutine(pointParticle, this.jumps, angle);
            yield return new WaitForSeconds(Random.Range(0.35f, 0.45f));

            this.startWorldPositions.Remove(startWorldPosition);
            this.startUIPositions.Remove(startUIPosition);
            this.pointParticles.Remove(pointParticle);
            this.iconParticles.Remove(iconParticle);
            this.pointParticlePool.Release(pointParticle);

            yield return UIAnimations.AnimateFlyRoutine(iconParticle.transform, this.settings, endUIPosiiton);
            this.iconParticlePool.Release(iconParticle);

            if (particleIterator.NextValue(out var moneyRange))
            {
                this.panel.IncrementMoney(moneyRange);
            }
        }
        
        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.pointParticles = new List<RectTransform>();
            this.pointParticlesCache = new List<RectTransform>();
            this.iconParticles = new List<ImageParticle>();
            this.iconParticlesCache = new List<ImageParticle>();
            this.startWorldPositions = new List<Vector3>();
            this.startWorldPositionsCache = new List<Vector3>();
            this.startUIPositions = new List<Vector3>();
            this.startUIPositionsCache = new List<Vector3>();
            
            var guiParticleSystem = context.GetService<GUIParticlePoolService>();
            this.iconParticlePool = guiParticleSystem.ImagePool;
            this.pointParticlePool = guiParticleSystem.PointPool;
            
            this.uiCamera = context.GetService<GUICameraService>().Camera;
            this.worldCamera = WorldCamera.Instance;

            this.worldViewport = context.GetService<GUIParticleViewportService>().WorldViewport;
        }

        void IGameLateUpdateElement.OnLateUpdate(float deltaTime)
        {
            this.UpdateIconParticles();
        }

        private void UpdateIconParticles()
        {
            this.pointParticlesCache.Clear();
            this.pointParticlesCache.AddRange(this.pointParticles);

            this.iconParticlesCache.Clear();
            this.iconParticlesCache.AddRange(this.iconParticles);

            this.startWorldPositionsCache.Clear();
            this.startWorldPositionsCache.AddRange(this.startWorldPositions);

            this.startUIPositionsCache.Clear();
            this.startUIPositionsCache.AddRange(this.startUIPositions);

            for (int i = 0, count = this.pointParticlesCache.Count; i < count; i++)
            {
                var point = this.pointParticlesCache[i];
                var icon = this.iconParticlesCache[i];
                var iconTransform = icon.transform;
                iconTransform.localScale = point.localScale;

                var startUIPosition = this.startUIPositionsCache[i];
                var startWorldPosition = this.startWorldPositionsCache[i];
                iconTransform.position = point.position + this.EvaluateOffset(startWorldPosition, startUIPosition);
            }
        }

        private Vector3 EvaluateOffset(Vector3 startWorldPosition, Vector3 startUIPosition)
        {
            var uiPosition = CameraUtils.FromWorldToUIPosition(this.worldCamera, this.uiCamera, startWorldPosition);
            return uiPosition - startUIPosition;
        }
    }
}