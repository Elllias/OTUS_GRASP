using UnityEngine;

namespace Game.GameEngine.AI
{
    public sealed class CommandArgs_MoveToPosition
    {
        public readonly Vector3 targetPosition;

        public CommandArgs_MoveToPosition(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
        }
    }
}