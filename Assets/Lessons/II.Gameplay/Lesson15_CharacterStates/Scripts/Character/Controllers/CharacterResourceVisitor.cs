using Entities;
using Game.GameEngine;
using GameSystem;
using Lessons.Character.Components;
using Lessons.Gameplay.Interaction;
using UnityEngine;

namespace Lessons.Character.Controllers
{
    public sealed class CharacterResourceVisitor : MonoBehaviour, IGameInitElement, IGameFinishElement
    {
        [SerializeField]
        private MonoEntity character;
        
        private ICollisionComponent _collisionComponent;
        private IGatherResourceComponent _gatherComponent;

        void IGameInitElement.InitGame()
        {
            _gatherComponent = character.Get<IGatherResourceComponent>();
            _collisionComponent = character.Get<ICollisionComponent>();
            _collisionComponent.OnEntered += this.OnCollisionEnter;
        }

        void IGameFinishElement.FinishGame()
        {
            _collisionComponent.OnEntered -= this.OnCollisionEnter;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IEntity entity) &&
                entity.TryGet(out IComponent_GetObjectType typeComponent) && 
                typeComponent.ObjectType == ObjectType.RESOURCE_OBJECT)
            {
                this.GatherResource(entity);
            }
        }

        private void GatherResource(IEntity resource)
        {
            var command = new GatherResourceCommand(resource);
            _gatherComponent.StartGather(command);
        }
    }
}