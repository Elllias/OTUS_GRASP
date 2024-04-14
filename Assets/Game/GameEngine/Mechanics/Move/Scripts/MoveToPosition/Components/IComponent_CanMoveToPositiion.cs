using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_CanMoveToPositiion
    {
        bool CanMove(Vector3 position);
    }
}