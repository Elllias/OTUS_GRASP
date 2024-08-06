using UnityEngine;
using Zenject;

namespace SampleGame
{
    public sealed class MoveController : IFixedTickable
    {
        private readonly ICharacter character;
        private readonly IMoveInput moveInput;

        public MoveController(ICharacter character, IMoveInput moveInput)
        {
            this.character = character;
            this.moveInput = moveInput;
        }

        void IFixedTickable.FixedTick()
        {
            this.character.Move(this.moveInput.GetDirection(), Time.deltaTime);
        }
    }
}