using UnityEngine;

namespace Lessons.Meta
{
    public sealed class QuestSelector : MonoBehaviour
    {
        [SerializeField]
        private QuestCatalog catalog;
        
        public QuestConfig SelectRandomQuest()
        {
            var quests = this.catalog.GetAllQuests();
            var index = Random.Range(0, quests.Length);
            var quest = quests[index];
            return quest;
        }
    }
}