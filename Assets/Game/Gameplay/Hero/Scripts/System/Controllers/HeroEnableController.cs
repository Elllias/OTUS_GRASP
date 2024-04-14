using Game.GameEngine.Mechanics;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroEnableController : 
        IGameInitElement,
        IGameStartElement,
        IGameFinishElement
    {
        private HeroService heroService;
        
        private IComponent_Enable heroComponent;

        [GameInject]
        public void Construct(HeroService heroService)
        {
            this.heroService = heroService;
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_Enable>();
        }

        void IGameStartElement.StartGame()
        {
            this.heroComponent.SetEnable(true);
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.SetEnable(false);
        }
    }
}