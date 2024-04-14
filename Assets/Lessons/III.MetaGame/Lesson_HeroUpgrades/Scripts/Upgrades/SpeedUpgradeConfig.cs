using Game.Meta;
using UnityEngine;

namespace Lessons.MetaGame.Upgrades
{
    [CreateAssetMenu(
        fileName = "SpeedUpgradeConfig",
        menuName = "Lessons/Meta/New SpeedUpgradeConfig"
    )]
    public sealed class SpeedUpgradeConfig : UpgradeConfig
    {
        public SpeedUpgradeTable speedTable;

        protected override void OnValidate()
        {
            base.OnValidate();
            this.speedTable.OnValidate(this.maxLevel);
        }

        public override Upgrade InstantiateUpgrade()
        {
            return new SpeedUpgrade(this);
        }
    }
}