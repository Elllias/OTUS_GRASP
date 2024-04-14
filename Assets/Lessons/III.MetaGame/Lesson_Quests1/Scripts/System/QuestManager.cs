using Game.Gameplay.Player;
using GameSystem;
using Lessons.Meta.Quests1;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame
{
    public sealed class QuestManager : MonoBehaviour, IGameConstructElement
    {
        [SerializeField]
        private QuestSelector selector;

        [SerializeField]
        private QuestFactory factory;
        
        private MoneyStorage moneyStorage;

        [ShowInInspector, ReadOnly]
        public Quest ActiveQuest { get; private set; }

        [Button]
        public void GenerateQuest()
        {
            var questConfig = this.selector.SelectQuestConfig();
            var quest = this.factory.InstantiateQuest(questConfig);
            this.ActiveQuest = quest;
            this.ActiveQuest.Start();
        }

        [Button]
        public void ReceiveReward()
        {
            var quest = this.ActiveQuest;
            if (quest is {IsCompleted: true})
            {
                this.moneyStorage.EarnMoney(quest.MoneyReward);
                this.factory.DestructQuest(quest);
                this.ActiveQuest = null;
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.moneyStorage = context.GetService<MoneyStorage>();
        }
    }
}