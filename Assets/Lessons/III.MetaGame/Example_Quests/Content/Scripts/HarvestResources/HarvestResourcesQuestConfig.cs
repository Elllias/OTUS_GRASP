using Game.GameEngine.GameResources;
using UnityEngine;

namespace Lessons.Meta
{
    [CreateAssetMenu(
        fileName = "HarvestResourcesQuestConfig",
        menuName = "Lessons/QuestExamples/New HarvestResourcesQuestConfig"
    )]
    public sealed class HarvestResourcesQuestConfig : QuestConfig
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType resourceType;

        [SerializeField]
        public int requiredResources;

        public override Quest InstantiateQuest()
        {
            return new HarvestResourcesQuest(this);
        }

        public override string Serialize(Quest quest)
        {
            var myQuest = (HarvestResourcesQuest) quest;
            return myQuest.CurrentResources.ToString();
        }

        public override void Deserialize(string state, Quest quest)
        {
            var myQuest = (HarvestResourcesQuest) quest;
            myQuest.CurrentResources = int.Parse(state);
        }
    }
}