using System.Collections.Generic;
using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class SpeedBoosterTest : MonoBehaviour, IGameConstructElement
    {
        [ShowInInspector, ReadOnly]
        private Booster booster;

        private GameContext gameContext;

        private MoneyStorage moneyStorage;

        private Dictionary<string, Booster> boosters;
        
        [Button]
        private void ActivateBooster(BoosterConfig config)
        {
            if (this.moneyStorage.Money < config.moneyPrice)
            {
                return;
            }
        
            this.moneyStorage.SpendMoney(config.moneyPrice);

            this.booster = config.InstantiateBooster();
            GameInjector.Inject(this.gameContext, this.booster);

            this.booster.Start();
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.gameContext = context;
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}