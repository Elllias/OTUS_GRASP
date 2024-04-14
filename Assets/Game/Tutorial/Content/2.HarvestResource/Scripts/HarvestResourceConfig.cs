using Game.GameEngine.GameResources;
using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Harvest Resource»",
        menuName = "Tutorial/New Config «Harvest Resource»"
    )]
    public sealed class HarvestResourceConfig : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.STONE;
    
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "CUT TREE";

        [SerializeField]
        public Sprite icon;
    }
}