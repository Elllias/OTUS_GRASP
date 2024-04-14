using Entities;
using GameSystem;
using Lessons.Character.Components;
using UnityEngine;

namespace Lessons.Character.Controllers
{
    public sealed class CharacterMovementController : MonoBehaviour,
        IGameInitElement,
        IGameFinishElement
    {
        [SerializeField]
        private MovementInput movementInput;
         
        [SerializeField]
        private MonoEntity character;

        private MoveInDirectionComponent _moveInDirection;

        void IGameInitElement.InitGame()
        {
            _moveInDirection = character.Get<MoveInDirectionComponent>();
            movementInput.MovementDirectionChanged += OnMovementDirectionChanged;
        }

        void IGameFinishElement.FinishGame()
        {
            movementInput.MovementDirectionChanged -= OnMovementDirectionChanged;
        }

        private void OnMovementDirectionChanged(Vector3 direction)
        {
            _moveInDirection.MoveInDirection(direction);
        }
    }
}