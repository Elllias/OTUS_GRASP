using System;
using Game.GameEngine.Mechanics;
using UnityEngine;
using HarvestResourceOperation = Lessons.Gameplay.CharacterInteraction.HarvestResourceOperation;

namespace Lessons.Gameplay.Lesson_CharacterInteraction
{
    [Serializable]
    public sealed class HarvestResourceAction_RotateToResource : IHarvestResourceAction
    {
        [SerializeField]
        private UTransformEngine transformEngine;

        public void Do(HarvestResourceOperation operation)
        {
            var target = operation.targetResource.Get<IComponent_GetPosition>().Position;
            this.transformEngine.LookAtPosition(target);
            Debug.Log("Look at resource!");
        }
    }
}