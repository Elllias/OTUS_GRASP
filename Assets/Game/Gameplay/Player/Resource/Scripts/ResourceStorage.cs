using System;
using Game.GameEngine.GameResources;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [AddComponentMenu("Gameplay/Player/Player Resource Storage")]
    public sealed class ResourceStorage : MonoBehaviour
    {
        public event Action<ResourceType, int> OnResourceChanged
        {
            add { this.source.OnValueChanged += value; }
            remove { this.source.OnValueChanged -= value; }
        }

        public event Action<ResourceType, int> OnResourceAdded;

        public event Action<ResourceType, int> OnResourceExtracted; 

        [ShowInInspector, ReadOnly]
        private ResourceSource source = new();

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void Setup(ResourceData[] resources)
        {
            this.source.Setup(resources);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void AddResource(ResourceType resourceType, int range)
        {
            this.source.Plus(resourceType, range);
            this.OnResourceAdded?.Invoke(resourceType, range);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void ExtractResource(ResourceType type, int range)
        {
            this.source.Minus(type, range);
            this.OnResourceExtracted?.Invoke(type, range);
        }

        public ResourceData[] GetAllResources()
        {
            return this.source.GetAll();
        }

        public int GetResource(ResourceType type)
        {
            return this.source[type];
        }
    }
}