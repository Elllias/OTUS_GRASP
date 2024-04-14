using UnityEngine;

namespace Game.GameEngine
{
    public sealed class WorldTransform : MonoBehaviour
    {
        public Transform Value
        {
            get { return this.value; }
        }

        [SerializeField]
        private Transform value;
    }
}