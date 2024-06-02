using System.Collections.Generic;
using GameEngine.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameEngine.Systems
{
    public sealed class PlayerResources : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<ResourceType, int> _resources = new();

        [Button]
        public void SetResource(ResourceType resourceType, int resource)
        {
            _resources[resourceType] = resource;
        }
        
        public int GetResource(ResourceType resourceType)
        {
            return _resources[resourceType];
        }

        public Dictionary<ResourceType, int> GetResources()
        {
            return _resources;
        }

        public void SetResources(Dictionary<ResourceType, int> resources)
        {
            _resources = resources;
        }
    }
}