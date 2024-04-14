using UnityEngine;

namespace Game.GameEngine
{
    public sealed class WorldPlaceObject : MonoBehaviour
    {
        public WorldPlaceType Type
        {
            get { return this.type; }
        }

        public Vector3 VisitPosition
        {
            get { return this.visitPoint.position; }
        }

        [SerializeField]
        private WorldPlaceType type;

        [SerializeField]
        private Transform visitPoint;
    }
}