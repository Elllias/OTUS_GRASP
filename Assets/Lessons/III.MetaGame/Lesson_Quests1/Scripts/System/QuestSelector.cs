using Lessons.Meta.Quests1;
using UnityEngine;

namespace Lessons.MetaGame
{
    public sealed class QuestSelector : MonoBehaviour
    {
        [SerializeField]
        private QuestConfig[] quests;
    
        public QuestConfig SelectQuestConfig()
        {
            var randomIndex = Random.Range(0, this.quests.Length);
            return this.quests[randomIndex];
        }
    }
}