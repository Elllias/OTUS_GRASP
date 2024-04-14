using System;
using Game.Meta;
using UnityEngine;

namespace Lessons.MetaGame.Upgrades
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        public string id;
        public int maxLevel;
        public UpgradePriceTable priceTable;

        protected virtual void OnValidate()
        {
            this.priceTable.OnValidate(this.maxLevel);
        }

        public abstract Upgrade InstantiateUpgrade();
    }
}