using UnityEngine;

namespace GameEngine
{
    //Нельзя менять!
    public sealed class Unit : MonoBehaviour
    {
        public string Type
        {
            get => type;
        }

        public int HitPoints
        {
            get => hitPoints;
            set => hitPoints = value;
        }

        public Vector3 Position
        {
            get => this.transform.position;
        }
        
        public Vector3 Rotation
        {
            get => this.transform.eulerAngles;
        }

        [SerializeField]
        private string type;
        
        [SerializeField]
        private int hitPoints;

        private void Reset()
        {
            this.type = this.name;
            this.hitPoints = 10;
        }
    }
}