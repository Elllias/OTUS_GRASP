using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "SpeedUpgrade",
        menuName = UpgradeExtensions.MENU_PATH + "New SpeedUpgrade"
    )]
    public sealed class SpeedUpgradeConfig : UpgradeConfig
    {
        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public SpeedUpgradeTable speedTable;
        
        public override Upgrade InstantiateUpgrade()
        {
            return new SpeedUpgrade(this);
        }

        protected override void Validate()
        {
            base.Validate();
            this.speedTable.OnValidate(this.maxLevel);
        }
    }
}