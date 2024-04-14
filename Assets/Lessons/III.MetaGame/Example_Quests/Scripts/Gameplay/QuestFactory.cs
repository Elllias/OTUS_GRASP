using GameSystem;
using UnityEngine;

namespace Lessons.Meta
{
    public sealed class QuestFactory : MonoBehaviour, IGameAttachElement
    {
        private GameContext gameContext;

        public Quest CreateQuest(QuestConfig config) //New quest...
        {
            var quest = config.InstantiateQuest();
            if (quest is IGameElement gameElement)
            {
                this.gameContext.RegisterElement(gameElement);
            }

            return quest;
        }

        public void DestroyQuest(Quest quest)
        {
            if (quest is IGameElement gameElement)
            {
                this.gameContext.UnregisterElement(gameElement);
            }
        }

        void IGameAttachElement.AttachGame(GameContext context)
        {
            this.gameContext = context;
        }
    }
}