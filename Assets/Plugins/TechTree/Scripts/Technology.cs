using System;
using System.Collections.Generic;

namespace TechTree
{
    public abstract class Technology
    {
        public string Id => _config.Id;
        public int Price => _config.Price;
        public bool IsUnlocked => _unlocked;
        public int MaxLevel => _config.MaxLevel;
        public int UpgradeCostDifference => _config.UpgradeCostDifference;

        public int Level;
        public int UpgradeCost;
        public IReadOnlyList<TechnologyDependency> Dependencies => _config.Dependencies;

        private readonly TechnologyConfig _config;
        private bool _unlocked;

        protected Technology(TechnologyConfig config)
        {
            _config = config;
        }

        internal void Initialize()
        {
            OnInitialize(_unlocked);
        }

        internal void Unlock()
        {
            if (_unlocked) return;
            
            ProcessUnlock();
            
            _unlocked = true;
        }

        protected abstract void OnInitialize(bool isUnlocked);
        protected abstract void ProcessUnlock();
    }
}