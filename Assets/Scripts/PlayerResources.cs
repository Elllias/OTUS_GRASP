using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Homeworks.SaveLoad
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> resources;

        public void SetResource(ResourceType resourceType, int resource)
        {
            this.resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return this.resources[resourceType];
        }
    }
}