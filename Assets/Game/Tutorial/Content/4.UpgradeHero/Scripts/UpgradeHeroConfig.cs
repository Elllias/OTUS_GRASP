using Game.GameEngine;
using Game.Localization;
using Game.Meta;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Upgrade Hero»",
        menuName = "Tutorial/Config «Upgrade Hero»"
    )]
    public sealed class UpgradeHeroConfig : ScriptableObject
    {
        [Header("Quest")]
        [SerializeField]
        public UpgradeConfig upgradeConfig;
        
        [SerializeField]
        public WorldPlaceType worldPlaceType =  WorldPlaceType.BLACKSMITH;

        [SerializeField]
        public PopupName requiredPopupName = PopupName.HERO_UPGRADES;
        
        [SerializeField]
        public int targetLevel = 3;
    
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "UPGRADE DAMAGE";

        [SerializeField]
        public Sprite icon;
    }
}