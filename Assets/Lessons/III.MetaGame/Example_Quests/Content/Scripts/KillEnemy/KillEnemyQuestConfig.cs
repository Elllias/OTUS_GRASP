using UnityEngine;

namespace Lessons.Meta
{
    [CreateAssetMenu(
        fileName = "KillEnemyQuestConfig",
        menuName = "Lessons/QuestExamples/New KillEnemyQuestConfig"
    )]
    public sealed class KillEnemyQuestConfig : QuestConfig
    {
        [Header("Quest")]
        [SerializeField]
        public int requiredKills;

        public override Quest InstantiateQuest()
        {
            return new KillEnemyQuest(this);
        }

        public override string Serialize(Quest quest)
        {
            var myQuest = (KillEnemyQuest) quest;
            return myQuest.CurrentKills.ToString();
        }

        public override void Deserialize(string state, Quest quest)
        {
            var myQuest = (KillEnemyQuest) quest;
            if (int.TryParse(state, out var currentKills))
            {
                myQuest.CurrentKills = currentKills;
            }
        }
    }
}