using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace TechTree
{
    public sealed class TechnologyDebug : MonoBehaviour
    {
        [Inject]
        private TechonologyManager technologyManager;

        [Button]
        public IReadOnlyList<Technology> GetTechnologies() => this.technologyManager.GetAllTechnologies();

        [Button]
        public bool Unlock(TechnologyConfig config)
        {
           return this.technologyManager.Unlock(config);
        }

        [Button]
        public bool CanUnlock(TechnologyConfig config) => this.technologyManager.CanUnlock(config);
        
        [Button]
        public bool IsUnlocked(TechnologyConfig config) => this.technologyManager.GetTechnology(config).IsUnlocked;

        [Button]
        public bool Upgrade(TechnologyConfig config)
        {
            return technologyManager.Upgrade(config);
        }

        [Button]
        public bool CanUpgrade(TechnologyConfig config)
        {
            return technologyManager.CanUpgrade(technologyManager.GetTechnology(config));
        }
    }
}