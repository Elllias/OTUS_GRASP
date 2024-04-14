using System;
using UnityEngine;

namespace Lessons.MetaGame.Inventory
{
    [Serializable]
    public sealed class InventoryItem
    {
        public string Name => this.name;
        public InventoryItemFlags Flags => this.flags;
        public InventoryItemMetadata Metadata => this.metadata;

        [SerializeField]
        private string name;

        [SerializeField]
        private InventoryItemFlags flags;

        [SerializeField]
        private InventoryItemMetadata metadata;

        [SerializeReference]
        private object[] components;

        public InventoryItem(
            string name,
            InventoryItemFlags flags,
            InventoryItemMetadata metadata,
            params object[] components
        )
        {
            this.name = name;
            this.flags = flags;
            this.metadata = metadata;
            this.components = components;
        }

        public T GetComponent<T>()
        {
            foreach (var component in this.components)
            {
                if (component is T tComponent)
                {
                    return tComponent;
                }
            }

            throw new Exception($"Component of type {typeof(T).Name} is not found!");
        }

        public InventoryItem Clone()
        {
            var count = this.components.Length;
            var components = new object[count];

            for (int i = 0; i < count; i++)
            {
                var component = this.components[i];
                if (component is ICloneable cloneable)
                {
                    component = cloneable.Clone();
                }

                components[i] = component;
            }
            
            return new InventoryItem(this.name, this.flags, this.metadata, components);
        }
    }
}