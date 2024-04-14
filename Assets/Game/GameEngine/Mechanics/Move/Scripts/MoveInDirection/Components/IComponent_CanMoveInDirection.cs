using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_CanMoveInDirection
    {
        bool CanMove(Vector3 direction);
    }
}