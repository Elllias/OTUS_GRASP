using System;
using System.Collections.Generic;
using Entities;
using GameSystem;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    [Serializable]
    public sealed class EnemyDetector : EntityDetectListener
    {
        [Space]
        [SerializeField]
        private ScriptableEntityCondition enemyCondition;

        private MeleeCombatInteractor combatInteractor;

        [GameInject]
        public void Construct(MeleeCombatInteractor combatInteractor)
        {
            this.combatInteractor = combatInteractor;
        }

        protected override bool MatchesEntity(IEntity entity)
        {
            return this.enemyCondition.IsTrue(entity);
        }

        protected override void OnEntitesChanged(List<IEntity> entities)
        {
            if (entities.Count > 0)
            {
                var targetEnemy = entities[0];
                this.combatInteractor.TryStartCombat(targetEnemy);
            }
        }
    }
}