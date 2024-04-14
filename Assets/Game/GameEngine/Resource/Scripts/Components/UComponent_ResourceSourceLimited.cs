using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine.GameResources
{
    [AddComponentMenu("GameEngine/GameResources/Component «Resource Source Limited»")]
    public sealed class UComponent_ResourceSourceLimited : MonoBehaviour, IComponent_ResourceSourceLimited
    {
        public event Action<ResourceType, int> OnResourcesChanged
        {
            add { this.stack.OnValueChanged += value; }
            remove { this.stack.OnValueChanged -= value; }
        }

        public event Action<int> OnLimitChanged
        {
            add { this.stack.OnLimitChanged += value; }
            remove { this.stack.OnLimitChanged -= value; }
        }

        public int AvailableSlots
        {
            get { return this.stack.AvailableCount; }
        }
        
        public int Limit
        {
            get { return this.stack.Limit; }
        }

        public bool IsLimit
        {
            get { return this.stack.IsLimit; }
        }

        [SerializeField]
        private UResourceSourceLimited stack;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void PutResources(ResourceType type, int amount)
        {
            this.stack.Plus(type, amount);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void SetupResources(ResourceData[] resources)
        {
            this.stack.Setup(resources);
        }
        
        [GUIColor(0, 1, 0)]
        [Button]
        public void ExtractResources(ResourceType type, int amount)
        {
            this.stack.Minus(type, amount);
        }

        public int GetSum()
        {
            return stack.GetSum();
        }

        public void Clear()
        {
            this.stack.Clear();
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void SetLimit(int limit)
        {
            this.stack.SetLimit(limit);
        }

        public int GetResources(ResourceType type)
        {
            return this.stack[type];
        }

        public ResourceData[] GetAllResources()
        {
            return this.stack.GetAll();
        }
    }
}