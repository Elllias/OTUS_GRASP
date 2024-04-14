using System.Collections.Generic;
using Entities;
using Game.GameEngine.Mechanics;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Hero
{
    public sealed class EntityDetectService :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        [ReadOnly]
        [ShowInInspector]
        private readonly List<IEntity> detectedEntities = new();

        [ReadOnly]
        [ShowInInspector]
        private readonly List<EntityDetectListener> observers = new ();

        private HeroService heroService;

        private IComponent_ColliderSensor heroComponent;

        public List<IEntity> GetDetectedEntitesUnsafe()
        {
            return this.detectedEntities;
        }

        [GameInject]
        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        public void AddListener(EntityDetectListener listener)
        {
            this.observers.Add(listener);
        }

        public void RemoveListener(EntityDetectListener listener)
        {
            this.observers.Remove(listener);
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_ColliderSensor>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnCollisionsUpdated += this.UpdateEntities;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnCollisionsUpdated -= this.UpdateEntities;
        }

        private void UpdateEntities()
        {
            this.detectedEntities.Clear();
            this.heroComponent.GetCollidersUnsafe(out var buffer, out var size);

            for (var i = 0; i < size; i++)
            {
                var collider = buffer[i];
                if (collider.TryGetComponent(out IEntity entity))
                {
                    this.detectedEntities.Add(entity);
                }
            }

            for (int i = 0, count = this.observers.Count; i < count; i++)
            {
                var listener = this.observers[i];
                listener.OnEntitiesUpdated(this.detectedEntities);
            }
        }
    }
}