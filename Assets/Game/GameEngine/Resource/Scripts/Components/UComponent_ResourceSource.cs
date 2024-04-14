using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.GameResources
{
    [AddComponentMenu("GameEngine/GameResources/Component «Resource Source»")]
    public sealed class UComponent_ResourceSource : MonoBehaviour, IComponent_ResourceSource
    {
        public event Action<ResourceType, int> OnResourcesChanged
        {
            add { this.table.OnValueChanged += value; }
            remove { this.table.OnValueChanged -= value; }
        }

        [SerializeField]
        private UResourceSource table;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void PutResources(ResourceType type, int amount)
        {
            this.table.Plus(type, amount);
        }
        
        [GUIColor(0, 1, 0)]
        [Button]
        public void ExtractResources(ResourceType type, int amount)
        {
            this.table.Minus(type, amount);
        }

        public int GetSum()
        {
            return this.table.GetSum();
        }

        public void Clear()
        {
            this.table.Clear();
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void SetupResources(ResourceData[] resources)
        {
            this.table.Setup(resources);
        }

        public int GetResources(ResourceType type)
        {
            return this.table[type];
        }

        public ResourceData[] GetAllResources()
        {
            return this.table.GetAll();
        }
    }
}