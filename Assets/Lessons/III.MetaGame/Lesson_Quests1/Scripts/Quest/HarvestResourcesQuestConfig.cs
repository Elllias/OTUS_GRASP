using Game.GameEngine.GameResources;
using UnityEngine;

namespace Lessons.Meta.Quests1
{
    [CreateAssetMenu(
        fileName = "Quest «Harvest Resources»",
        menuName = "Lessons/New Quest «Harvest Resources»"
    )]
    public sealed class HarvestResourcesQuestConfig : QuestConfig
    {
        [SerializeField]
        public ResourceType resourceType;

        [SerializeField]
        public int requiredResources;

        public override Quest InstatiateQuest()
        {
            return new HarvestResourcesQuest(this);
        }
    }
}