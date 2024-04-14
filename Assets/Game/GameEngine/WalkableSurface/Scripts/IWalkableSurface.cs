using UnityEngine;

namespace Game.GameEngine
{
    public interface IWalkableSurface
    {
        public bool IsAvailablePosition(Vector3 position);

        public bool FindAvailablePosition(Vector3 position, out Vector3 clampedPosition);
    }
}