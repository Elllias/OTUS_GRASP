using UnityEngine;

namespace Game.Meta
{
    [CreateAssetMenu(
        fileName = "HitPointsUpgrade",
        menuName = UpgradeExtensions.MENU_PATH + "New HitPointsUpgrade"
    )]
    public sealed class HitPointsUpgradeConfig : UpgradeConfig
    {
        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public HitPointsUpgradeTable hitPointsTable;

        public override Upgrade InstantiateUpgrade()
        {
            return new HitPointsUpgrade(this);
        }

        protected override void Validate()
        {
            base.Validate();
            this.hitPointsTable.OnValidate(this.maxLevel);
        }
    }
}