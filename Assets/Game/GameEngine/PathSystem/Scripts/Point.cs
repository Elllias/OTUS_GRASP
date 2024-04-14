using UnityEngine;

namespace Game.GameEngine.PathSystem
{
    public sealed class Point : MonoBehaviour
    {
        public bool IsActive
        {
            get { return this.gameObject.activeInHierarchy; }
        }

        public Vector3 WorldPosition
        {
            get { return this.transform.position; }
        }

        public float GetDistanceTo(Point point2)
        {
            var posiiton1 = this.WorldPosition;
            var position2 = point2.WorldPosition;
            
            var vector = position2 - posiiton1;
            vector.y = 0;
            return vector.magnitude;
        }
        
        public float GetDistanceTo(Vector3 position)
        {
            var vector = this.WorldPosition - position;
            vector.y = 0;
            return vector.magnitude;
        }
    }
}