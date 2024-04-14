using System;
using Elementary;
using Game.GameEngine.GameResources;
using Game.Gameplay.Conveyors;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class Component_UnloadZone : IComponent_UnloadZone
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
            get { return this.resourceType; }
        }

        public Vector3 ParticlePosition
        {
            get { return this.particlePoint.position; }
        }

        private readonly IVariableLimited<int> storage;

        private readonly ResourceType resourceType;

        private readonly Transform particlePoint;

        public Component_UnloadZone(IVariableLimited<int> storage, ResourceType resourceType, Transform particlePoint)
        {
            this.storage = storage;
            this.resourceType = resourceType;
            this.particlePoint = particlePoint;
        }

        public void SetupAmount(int currentAmount)
        {
            this.storage.Current = currentAmount;
        }

        public int ExtractAll()
        {
            var resources = this.storage.Current;
            this.storage.Current = 0;
            return resources;
        }
    }
}