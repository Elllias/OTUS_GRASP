using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace TechTree
{
    public sealed class TechonologyManager : IInitializable
    {
        public event Action<Technology> OnUnlocked;

        private readonly IMoneyStorage moneyStorage;
        private readonly Dictionary<string, Technology> technologies;

        public TechonologyManager(IMoneyStorage moneyStorage, IEnumerable<Technology> technologies)
        {
            this.moneyStorage = moneyStorage;
            this.technologies = technologies.ToDictionary(it => it.Id);
        }

        public void Initialize()
        {
            foreach (Technology technology in this.technologies.Values)
            {
                technology.Initialize();
            }
        }

        public Technology GetTechnology(TechnologyConfig config)
        {
            return this.technologies[config.Id];
        }

        public Technology GetTechnology(string id)
        {
            return this.technologies[id];
        }

        public Technology[] GetAllTechnologies()
        {
            return this.technologies.Values.ToArray();
        }

        public bool CanUnlock(TechnologyConfig config)
        {
            if (this.technologies.TryGetValue(config.Id, out Technology technology))
            {
                return this.CanUnlock(technology);
            }

            return false;
        }

        public bool CanUnlock(Technology technology)
        {
            if (technology.IsUnlocked)
            {
                return false;
            }

            if (!this.moneyStorage.CanSpend(technology.Price))
            {
                return false;
            }

            IReadOnlyList<TechnologyDependency> dependencies = technology.Dependencies;

            for (int i = 0, count = dependencies.Count; i < count; i++)
            {
                TechnologyDependency dependencyInfo = dependencies[i];
                if (!this.technologies.TryGetValue(dependencyInfo.Technology.Id, out Technology dependency))
                {
                    throw new Exception($"Dependency technology with id {dependencyInfo.Technology.Id} is not found!");
                }
                
                if (!dependency.IsUnlocked
                    || dependency.Level < dependencyInfo.Level)
                {
                    return false;
                }
            }

            return true;
        }

        public bool Unlock(TechnologyConfig config)
        {
            if (this.technologies.TryGetValue(config.Id, out Technology technology))
            {
                return this.Unlock(technology);
            }

            return false;
        }

        public bool Unlock(Technology technology)
        {
            if (!this.CanUnlock(technology))
            {
                return false;
            }

            this.moneyStorage.Spend(technology.Price);
            technology.Unlock();
            Upgrade(technology);

            this.OnUnlocked?.Invoke(technology);
            return true;
        }

        public bool Upgrade(TechnologyConfig config)
        {
            if (technologies.TryGetValue(config.Id, out Technology technology))
            {
                return Upgrade(technology);
            }

            return false;
        }

        private bool Upgrade(Technology technology)
        {
            if (!CanUpgrade(technology))
            {
                return false;
            }
                
            moneyStorage.Spend(technology.UpgradeCost);
            technology.UpgradeCost += technology.UpgradeCostDifference;
            technology.Level += 1;

            return true;
        }

        public bool CanUpgrade(Technology technology)
        {
            if (!technology.IsUnlocked)
            {
                return false;
            }
            
            if (technology.Level >= technology.MaxLevel)
            {
                return false;
            }

            if (!moneyStorage.CanSpend(technology.UpgradeCost))
            {
                return false;
            }

            return true;
        }
    }
}