using UnityEngine;

namespace Lessons.Meta
{
    public abstract class QuestConfig : ScriptableObject
    {
        [Space]
        [SerializeField]
        public string id;

        [Space]
        [SerializeField]
        public int moneyReward;

        public abstract Quest InstantiateQuest();
        
        public abstract string Serialize(Quest quest);

        public abstract void Deserialize(string state, Quest quest);
    }
}