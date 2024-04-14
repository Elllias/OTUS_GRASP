using UnityEngine;

namespace Lessons.Architecture.GameSystem
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField]
        private float speed = 2.5f;
        
        public void Move(Vector3 offset)
        {
            this.transform.position += offset * this.speed;
        }

        public Vector3 GetPosition()
        {
            return this.transform.position;
        }
    }
}