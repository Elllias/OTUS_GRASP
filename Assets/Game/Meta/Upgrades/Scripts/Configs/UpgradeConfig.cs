using System;
using UnityEngine;

namespace Game.Meta
{
    public abstract class UpgradeConfig : ScriptableObject
    {
        protected const float SPACE_HEIGHT = 10.0f;

        [SerializeField]
        public string id;
        
        [Range(2, 99)]
        [SerializeField]
        public int maxLevel = 2;

        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public UpgradeMetadata metadata;

        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public UpgradeInitialStats initialStats;

        [Space(SPACE_HEIGHT)]
        [SerializeField]
        public UpgradePriceTable priceTable;
        
        public abstract Upgrade InstantiateUpgrade();

        private void OnValidate()
        {
            try
            {
                this.Validate();
            }
            catch (Exception)
            {
                // ignored
            }
        }
        
        protected virtual void Validate()
        {
            this.priceTable.OnValidate(this.maxLevel);
        }
    }
}