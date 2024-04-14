using System;
using Elementary;
using Game.GameEngine;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class WorldPlaceVisitor : TriggerVisitor<WorldPlaceTrigger>
    {
        [Space]
        [SerializeField]
        private float visitDelay = 0.2f;

        private WorldPlaceVisitInteractor visitInteractor;

        [GameInject]
        public void Construct(WorldPlaceVisitInteractor placeObservable)
        {
            this.visitInteractor = placeObservable;
        }

        protected override bool CanEnter(WorldPlaceTrigger entity)
        {
            return true;
        }

        protected override ICondition ProvideConditions(WorldPlaceTrigger target)
        {
            return new ConditionComposite(
                new ConditionCountdown(this.monoContext, seconds: this.visitDelay, startInstantly: true),
                new Condition_Entity_IsNotMoving(this.HeroService.GetHero())
            );
        }

        protected override void OnHeroVisit(WorldPlaceTrigger target)
        {
            var placeType = target.PlaceType;
            if (this.visitInteractor.IsVisiting && this.visitInteractor.CurrentPlace != placeType)
            {
                this.visitInteractor.EndVisit();
            }

            this.visitInteractor.StartVisit(placeType);
        }

        protected override void OnHeroQuit(WorldPlaceTrigger target)
        {
            var placeType = target.PlaceType;
            if (this.visitInteractor.IsVisiting && placeType == target.PlaceType)
            {
                this.visitInteractor.EndVisit();
            }
        }
    }
}