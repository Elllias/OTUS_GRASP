using System.Numerics;
using Entities;

namespace Lessons.Gameplay.CharacterInteraction
{
    public sealed class HarvestResourceOperation
    {
        public readonly IEntity targetResource;
        
        public bool isCompleted;

        public HarvestResourceOperation(IEntity targetResource)
        {
            this.targetResource = targetResource;
        }
    }
}