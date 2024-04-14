using UnityEngine;

namespace Lessons.Architecture.DI
{
    public sealed class MoveController : 
        IGameStartListener,
        IGameFinishListener
    {
        private IMoveInput moveInput;
        private Character character;

        [Inject]
        public void Construct(IMoveInput moveInput, Character character)
        {
            Debug.Log("CONSTRUCT CONTROLLER");
            this.moveInput = moveInput;
            this.character = character;
        }

        void IGameStartListener.OnStartGame()
        {
            this.moveInput.OnMove += this.OnMove;
        }

        void IGameFinishListener.OnFinishGame()
        {
            this.moveInput.OnMove -= this.OnMove;
        }

        private void OnMove(Vector2 direction)
        {
            var offset = new Vector3(direction.x, 0, direction.y) * Time.deltaTime;
            this.character.Move(offset);
        }
    }
}