using System;
using Elementary;
using Game.GameEngine.GameResources;
using Game.Gameplay.Conveyors;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Component_LoadZone : IComponent_LoadZone
    {
        public event Action<int> OnAmountChanged
        {
            add { this.storage.OnValueChanged += value; }
            remove { this.storage.OnValueChanged -= value; }
        }

        public int MaxAmount
        {
            get { return this.storage.MaxValue; }
        }

        public int CurrentAmount
        {
            get { return this.storage.Current; }
        }

        public int AvailableAmount
        {
            get { return this.storage.MaxValue - this.storage.Current; }
        }

        public bool IsFull
        {
            get { return this.storage.IsLimit; }
        }

        public bool IsEmpty
        {
            get { return this.storage.Current <= 0; }
        }

        public ResourceType ResourceType
        {
            get { return resourceType; }
        }

        private readonly IVariableLimited<int> storage;

        private readonly ResourceType resourceType;

        public Component_LoadZone(IVariableLimited<int> storage, ResourceType resourceType)
        {
            this.storage = storage;
            this.resourceType = resourceType;
        }

        public void SetupAmount(int currentAmount)
        {
            this.storage.Current = currentAmount;
        }

        public void PutAmount(int range)
        {
            this.storage.Current += range;
        }
    }
}