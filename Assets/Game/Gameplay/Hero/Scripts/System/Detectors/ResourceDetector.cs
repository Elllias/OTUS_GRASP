using System;
using System.Collections.Generic;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class ResourceDetector : EntityDetectListener
    {
        [Space]
        [SerializeField]
        private ScriptableEntityCondition resourceCondition;

        private HarvestResourceInteractor resourceInteractor;

        [GameInject]
        public void Construct(HarvestResourceInteractor interactor)
        {
            this.resourceInteractor = interactor;
        }

        protected override bool MatchesEntity(IEntity entity)
        {
            return this.resourceCondition.IsTrue(entity);
        }

        protected override void OnEntitesChanged(List<IEntity> entities)
        {
            if (entities.Count > 0)
            {
                var targetResource = entities[0];
                this.resourceInteractor.TryStartHarvest(targetResource);
            }
        }
    }
}