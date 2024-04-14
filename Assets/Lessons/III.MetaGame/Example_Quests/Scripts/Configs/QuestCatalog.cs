using System;
using UnityEngine;

namespace Lessons.Meta
{
    [CreateAssetMenu(
        fileName = "QuestCatalog",
        menuName = "Lessons/QuestExamples/New QuestCatalog"
    )]
    public sealed class QuestCatalog : ScriptableObject
    {
        [SerializeField]
        private QuestConfig[] quests;

        public QuestConfig[] GetAllQuests()
        {
            return this.quests;
        }

        public QuestConfig FindQuest(string id)
        {
            for (int i = 0, count = this.quests.Length; i < count; i++)
            {
                var config = this.quests[i];
                if (config.id == id)
                {
                    return config;
                }
            }
            
            throw new Exception($"Quest config with id {id} is not found!");
        }
    }
}