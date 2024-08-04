using System;
using UnityEngine;

namespace Sample
{
    //Нельзя менять!
    [Serializable]
    public sealed class Item
    {
        public string Name => this.name;

        [SerializeField]
        private string name;

        [SerializeField]
        private ItemFlags flags;

        [SerializeReference]
        private object[] components;

        public Item(
            string name,
            ItemFlags flags,
            params object[] components
        )
        {
            this.name = name;
            this.flags = flags;
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

        public Item Clone()
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
            
            return new Item(this.name, this.flags, components);
        }
    }
}