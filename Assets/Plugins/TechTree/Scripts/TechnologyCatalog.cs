using System;
using System.Collections.Generic;
using UnityEngine;

namespace TechTree
{
    [CreateAssetMenu(
        fileName = "TechnologyCatalog",
        menuName = "Technologies/New TechnologyCatalog"
    )]
    public sealed class TechnologyCatalog : ScriptableObject
    {
        [SerializeField]
        private TechnologyConfig[] technologies;

        public TechnologyConfig GetTechnology(string id)
        {
            for (int i = 0, count = this.technologies.Length; i < count; i++)
            {
                TechnologyConfig technology = this.technologies[i];
                if (technology.Id == id)
                {
                    return technology;
                }
            }

            throw new Exception($"Technology with id is not found {id}");
        }

        public IReadOnlyList<TechnologyConfig> GetAllTechnologies()
        {
            return this.technologies;
        }

        public bool TryGetTechnology(string id, out TechnologyConfig config)
        {
            for (int i = 0, count = this.technologies.Length; i < count; i++)
            {
                TechnologyConfig technology = this.technologies[i];
                if (technology.Id == id)
                {
                    config = technology;
                    return true;
                }
            }

            config = default;
            return false;
        }
    }
}