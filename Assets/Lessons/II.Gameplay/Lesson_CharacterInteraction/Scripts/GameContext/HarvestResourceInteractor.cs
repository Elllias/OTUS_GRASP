using System;
using System.Collections.Generic;
using Entities;
using GameSystem;
using Lessons.Gameplay.Common;
using Lessons.Gameplay.Lesson_CharacterInteraction;
using UnityEngine;

namespace Lessons.Gameplay.CharacterInteraction
{
    [Serializable]
    public sealed class HarvestResourceInteractor :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        public bool IsHarvesting
        {
            get { return this.heroComponent.IsHarvesting; }
        }

        private HeroService heroService;

        private IComponent_HarvestResource heroComponent;

        [SerializeField]
        private ScriptableEntityCondition isResourceActive;

        private readonly List<IHarvestResourceAction> finishActions = new();

        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        public void RegisterFinishAction(IHarvestResourceAction action)
        {
            this.finishActions.Add(action);
        }
        
        public bool CanHarvest(IEntity resource)
        {
            if (this.IsHarvesting)
            {
                return false;
            }

            if (!this.isResourceActive.IsTrue(resource))
            {
                return false;
            }

            var operation = new HarvestResourceOperation(resource);
            if (!this.heroComponent.CanStartHarvest(operation))
            {
                return false;
            }

            return true;
        }

        public void StartHarvest(IEntity resource)
        {
            if (!this.CanHarvest(resource))
            {
                Debug.LogWarning("Can't harvest");
                return;
            }

            var operation = new HarvestResourceOperation(resource);
            this.heroComponent.StartHarvest(operation);
            Debug.Log("Interactor: Start harvest");
        }

        public void CancelHarvest()
        {
            if (this.IsHarvesting)
            {
                this.heroComponent.StopHarvest();
                Debug.Log("Interactor: cancel harvest");
            }
        }

        private void OnHarvestFinished(HarvestResourceOperation operation)
        {
            for (int i = 0, count = this.finishActions.Count; i < count; i++)
            {
                var action = this.finishActions[i];
                action.Do(operation);
            }
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_HarvestResource>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnFinished += this.OnHarvestFinished;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnFinished -= this.OnHarvestFinished;
        }
    }
}