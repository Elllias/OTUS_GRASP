using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public abstract class TriggerObserver :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        protected HeroService HeroService { get; private set; }

        private IComponent_TriggerSensor heroComponent;

        [GameInject]
        public void Construct(HeroService heroService)
        {
            this.HeroService = heroService;
        }
        
        public virtual void InitGame()
        {
            this.heroComponent = this.HeroService.GetHero().Get<IComponent_TriggerSensor>();
        }

        public virtual void ReadyGame()
        {
            this.heroComponent.OnEntered += this.OnHeroEntered;
            this.heroComponent.OnExited += this.OnHeroExited;
        }

        public virtual void FinishGame()
        {
            this.heroComponent.OnEntered -= this.OnHeroEntered;
            this.heroComponent.OnExited -= this.OnHeroExited;
        }

        protected virtual void OnHeroEntered(Collider other)
        {
        }

        protected virtual void OnHeroExited(Collider other)
        {
        }
    }
    
    public abstract class TriggerObserver<T> : TriggerObserver where T : class
    {
        protected sealed override void OnHeroEntered(Collider other)
        {
            if (other.TryGetComponent(out T target))
            {
                this.OnHeroEntered(target);
            }
        }

        protected sealed override void OnHeroExited(Collider other)
        {
            if (other.TryGetComponent(out T target))
            {
                this.OnHeroExited(target);
            }
        }

        protected abstract void OnHeroEntered(T target);

        protected abstract void OnHeroExited(T target);
    }
}