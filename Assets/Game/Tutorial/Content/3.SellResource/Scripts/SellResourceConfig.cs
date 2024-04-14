using Game.GameEngine.GameResources;
using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Tutorial Step «Sell Resource»",
        menuName = "Tutorial/New Tutorial Step «Sell Resource»"
    )]
    public sealed class SellResourceConfig : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public ResourceType targetResourceType = ResourceType.STONE;
    
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "SELL TREE";

        [SerializeField]
        public Sprite icon;
    }
}