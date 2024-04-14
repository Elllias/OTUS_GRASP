using GameSystem;
using Lessons.Meta.Quests1;
using UnityEngine;

namespace Lessons.MetaGame
{
    public sealed class QuestFactory : MonoBehaviour, IGameConstructElement
    {
        private GameContext gameContext;
            
        public Quest InstantiateQuest(QuestConfig config)
        {
            var quest = config.InstatiateQuest();
            if (quest is IGameElement gameElement)
            {
                this.gameContext.RegisterElement(gameElement);
            }

            return quest;
        }

        public void DestructQuest(Quest quest)
        {
            if (quest is IGameElement gameElement)
            {
                this.gameContext.UnregisterElement(gameElement);
            }
        }

        void IGameConstructElement.ConstructGame(GameContext context)
        {
            this.gameContext = context;
        }
    }
}