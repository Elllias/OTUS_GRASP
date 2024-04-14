using System;
using Elementary;
using Entities;
using Game.Gameplay.Player;
using GameSystem;
using UnityEngine;
using ICondition = Elementary.ICondition;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class VendorVisitor : TriggerVisitor<IEntity>
    {
        private VendorInteractor vendorInteractor;

        [SerializeField]
        private ScriptableEntityCondition vendorCondition;

        private readonly ICondition stayCondition;

        public VendorVisitor()
        {
            this.stayCondition = new Condition(true);
        }

        [GameInject]
        public void Construct(VendorInteractor vendorInteractor)
        {
            this.vendorInteractor = vendorInteractor;
        }

        protected override bool CanEnter(IEntity target)
        {
            return this.vendorCondition.IsTrue(target);
        }

        protected override ICondition ProvideConditions(IEntity target)
        {
            return this.stayCondition;
        }

        protected override void OnHeroVisit(IEntity entity)
        {
            this.vendorInteractor.SellResources(entity);
        }

        protected override void OnHeroQuit(IEntity target)
        {
        }
    }
}