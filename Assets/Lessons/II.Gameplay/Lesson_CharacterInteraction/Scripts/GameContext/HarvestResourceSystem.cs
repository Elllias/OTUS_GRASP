using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Lessons.Gameplay.Common;
using UnityEngine;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class HarvestResourceSystem : MonoBehaviour,
        IGameElementGroup,
        IGameServiceGroup,
        IGameConstructElement
    {
        [SerializeField]
        private HarvestResourceInteractor interactor = new();

        public IEnumerable<IGameElement> GetElements()
        {
            yield return this.interactor;
        }

        public IEnumerable<object> GetServices()
        {
            yield return this.interactor;
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            var heroService = context.GetService<HeroService>();
            this.interactor.Construct(heroService);
            
            var resourceStorage = context.GetService<ResourceStorage>();
            this.interactor.RegisterFinishAction(new HarvestResourceAction_DestroyResource());
            this.interactor.RegisterFinishAction(new HarvestResourceAction_AddResourcesToStorage(resourceStorage));
        }
    }
}