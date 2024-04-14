using Game.Gameplay.Player;
using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Meta.Quests1
{
    public sealed class QuestDebug : MonoBehaviour, IGameConstructElement
    {
        [ShowInInspector, ReadOnly]
        private Quest currentQuest;

        private GameContext gameContext;

        private MoneyStorage moneyStorage;

        [Button]
        public void LaunchQuest(QuestConfig config)
        {
            this.currentQuest = config.InstatiateQuest();
            if (this.currentQuest is IGameElement gameElement)
            {
                this.gameContext.RegisterElement(gameElement);
            }

            this.currentQuest.Start();
        }

        [Button]
        public void ReceiveReward()
        {
            if (this.currentQuest is not {IsCompleted: true})
            {
                return;
            }

            this.moneyStorage.EarnMoney(this.currentQuest.MoneyReward);
            if (this.currentQuest is IGameElement gameElement)
            {
                this.gameContext.UnregisterElement(gameElement);
            }

            this.currentQuest = null;
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.gameContext = context;
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}