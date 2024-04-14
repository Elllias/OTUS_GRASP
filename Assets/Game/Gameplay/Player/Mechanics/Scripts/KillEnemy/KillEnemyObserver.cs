using System;
using Entities;
using Game.SceneAudio;
using Game.GameEngine.Mechanics;
using Game.Gameplay.Hero;
using GameSystem;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Gameplay.Player
{
    [Serializable]
    public sealed class KillEnemyObserver :
        IGameInitElement,
        IGameReadyElement,
        IGameFinishElement
    {
        private HeroService heroService;

        private MoneyStorage moneyStorage;

        private MoneyPanelAnimator_AddJumpedMoney uiAnimator;

        private IComponent_MeleeCombat heroComponent;

        [SerializeField]
        private int minMoneyReward = 100;

        [SerializeField]
        private int maxMoneyReward = 300;

        [Space]
        [SerializeField]
        private AudioClip moneySFX;

        [GameInject]
        public void Construct(
            HeroService heroService,
            MoneyStorage moneyStorage,
            MoneyPanelAnimator_AddJumpedMoney uiAnimator
        )
        {
            this.heroService = heroService;
            this.moneyStorage = moneyStorage;
            this.uiAnimator = uiAnimator;
        }

        void IGameInitElement.InitGame()
        {
            this.heroComponent = this.heroService.GetHero().Get<IComponent_MeleeCombat>();
        }

        void IGameReadyElement.ReadyGame()
        {
            this.heroComponent.OnCombatStopped += this.OnCombatEnded;
        }

        void IGameFinishElement.FinishGame()
        {
            this.heroComponent.OnCombatStopped -= this.OnCombatEnded;
        }

        private void OnCombatEnded(CombatOperation operation)
        {
            if (operation.targetDestroyed)
            {
                this.AddMoneyReward(operation.targetEntity);
            }
        }

        private void AddMoneyReward(IEntity targetEnemy)
        {
            var reward = Random.Range(this.minMoneyReward, this.maxMoneyReward + 1);

            //Добавляем монеты в систему
            this.moneyStorage.EarnMoney(reward);

            //Добавляем монеты в UI через партиклы
            var particlePosiiton = targetEnemy.Get<IComponent_GetPosition>().Position;
            this.uiAnimator.PlayIncomeFromWorld(particlePosiiton, reward);

            //Звук
            SceneAudioManager.PlaySound(SceneAudioType.INTERFACE, this.moneySFX);
        }
    }
}