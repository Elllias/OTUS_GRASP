using UnityEngine;

namespace Lessons.Meta.Quests1
{
    public abstract class QuestConfig : ScriptableObject
    {
        [SerializeField]
        public string id;

        [SerializeField]
        public int moneyReward;

        public abstract Quest InstatiateQuest();
    }
}