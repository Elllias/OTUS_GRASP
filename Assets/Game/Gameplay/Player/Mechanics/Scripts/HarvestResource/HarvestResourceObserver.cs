using System;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using Game.SceneAudio;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [Serializable]
    public sealed class HarvestResourceObserver :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        [SerializeField]
        private AudioClip collectSFX;

        private HeroService heroService;

        private ResourceStorage resourceStorage;

        private ResourcePanelAnimator_AddJumpedResources resourceAnimator;

        private IComponent_HarvestResource heroComponent;

        [GameInject]
        public void Construct(
            HeroService heroService,
            ResourceStorage resourceStorage,
            ResourcePanelAnimator_AddJumpedResources resourceAnimator
        )
        {
            this.heroService = heroService;
            this.resourceStorage = resourceStorage;
            this.resourceAnimator = resourceAnimator;
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_HarvestResource>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnHarvestStopped += this.OnHarvestStopped;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnHarvestStopped -= this.OnHarvestStopped;
        }

        private void OnHarvestStopped(HarvestResourceOperation operation)
        {
            if (operation.isCompleted)
            {
                this.AddResources(operation);
            }
        }

        private void AddResources(HarvestResourceOperation operation)
        {
            var resourceType = operation.resourceType;
            var resourceAmount = operation.resourceCount;
            this.resourceStorage.AddResource(resourceType, resourceAmount);

            var resourcePosition = operation.targetResource.Get<IComponent_GetPosition>().Position;
            this.resourceAnimator.PlayIncomeFromWorld(resourcePosition, resourceType, resourceAmount);

            SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            //
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
            // SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.collectSFX);
        }
    }
}