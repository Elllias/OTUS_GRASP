using System;
using Entities;
using Game.GameEngine.GameResources;
using Game.GameEngine.Mechanics;
using UnityEngine;

namespace Lessons.Gameplay.Interaction
{
    [Serializable]
    public sealed class GatherResourceCommand
    {
        public ResourceType Type
        {
            get { return this.typeComponent.Type; }
        }

        public int Amount
        {
            get { return this.amountComponent.Count; }
        }

        public Vector3 Position
        {
            get { return this.positionComponent.Position; }
        }

        public IEntity Resource
        {
            get { return this.resource; }
        }
        
        private readonly IEntity resource;
        private readonly IComponent_GetPosition positionComponent;
        private readonly IComponent_GetResourceCount amountComponent;
        private readonly IComponent_GetResourceType typeComponent;

        private bool isCompleted;

        public GatherResourceCommand(IEntity resource)
        {
            this.resource = resource;

            this.typeComponent = resource.Get<IComponent_GetResourceType>();
            this.amountComponent = resource.Get<IComponent_GetResourceCount>();
            this.positionComponent = resource.Get<IComponent_GetPosition>();
        }

        public void Complete()
        {
            this.isCompleted = true;
        }

        public bool IsCompleted()
        {
            return this.isCompleted;
        }
    }
}