using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "DamageUpgrade",
        menuName = UpgradeExtensions.MENU_PATH + "New DamageUpgrade"
    )]
    public sealed class DamageUpgradeConfig : UpgradeConfig
    {
        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public DamageUpgradeTable damageTable;

        public override Upgrade InstantiateUpgrade()
        {
            return new DamageUpgrade(this);
        }

        protected override void Validate()
        {
            base.Validate();
            this.damageTable.OnValidate(this.maxLevel);
        }
    }
}