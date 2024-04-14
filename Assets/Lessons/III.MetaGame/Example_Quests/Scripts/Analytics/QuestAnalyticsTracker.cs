using GameSystem;
using Game.Meta;
using UnityEngine;

namespace Lessons.Meta
{
    public sealed class QuestAnalyticsTracker : MonoBehaviour, 
        IGameReadyElement,
        IGameFinishElement
    {
        [SerializeField]
        private QuestManager questManager;
        
        void IGameReadyElement.ReadyGame()
        {
            this.questManager.OnQuestTaken += this.OnStartQuest;
            this.questManager.OnQuestRewardReceived += this.OnReceiveRewardQuest;
        }

        void IGameFinishElement.FinishGame()
        {
            this.questManager.OnQuestTaken -= this.OnStartQuest;
            this.questManager.OnQuestRewardReceived -= this.OnReceiveRewardQuest;
        }

        private void OnStartQuest(Quest quest)
        {
            QuestsAnalytics.LogQuestStarted(quest);
        }

        private void OnReceiveRewardQuest(Quest quest)
        {
            QuestsAnalytics.LogQuestRewardReceived(quest);
        }
    }
}