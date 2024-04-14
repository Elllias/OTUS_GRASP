using Entities;
using Lessons.Character.Components;
using UnityEngine;

namespace Lessons.Character
{
    [DefaultExecutionOrder(-100)]
    public sealed class CharacterEntity : MonoEntityBase
    {
        private void Awake()
         {
             var characterModel = this.GetComponent<CharacterModel>();
             Add(new MoveInDirectionComponent(characterModel.core.movement.movementDirection));
             Add(new GatherResourceComponent(characterModel.core.gathering.process));
             Add(new CollisionComponent(characterModel.core.collision.sensor));
         }
    }
}