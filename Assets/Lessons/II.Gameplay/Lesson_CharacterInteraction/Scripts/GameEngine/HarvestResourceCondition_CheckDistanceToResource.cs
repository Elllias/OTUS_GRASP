using System;
using Game.GameEngine.Mechanics;
using UnityEngine;
using HarvestResourceOperation = Lessons.Gameplay.CharacterInteraction.HarvestResourceOperation;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    [Serializable]
    public sealed class HarvestResourceCondition_CheckDistanceToResource : IHarvestResourceCondition
    {
        [SerializeField]
        private UTransformEngine transform;

        [SerializeField]
        private float minDistance = 1.25f;
        
        public bool IsTrue(HarvestResourceOperation operation)
        {
            Vector3 targetPosition = operation.targetResource.Get<IComponent_GetPosition>().Position;
            Vector3 myPosition = this.transform.WorldPosition;
            var distanceVector = targetPosition - myPosition;
            var isTrue = distanceVector.magnitude <= this.minDistance;
            Debug.Log($"CHECK CONDITION {isTrue} {distanceVector.magnitude}");
            return isTrue;
        }
    }
}