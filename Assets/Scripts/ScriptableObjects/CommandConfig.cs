using UnityEngine;

namespace ScriptableObjects
{
    public class CommandConfig : ScriptableObject
    {
        [Header("Units data")]
        [SerializeField] private int _count;
        [SerializeField] private int _health;
        [SerializeField] private float _moveSpeed;

        public int GetCount()
        {
            return _count;
        }
        
        public int GetHealth()
        {
            return _health;
        }
        
        public float GetMoveSpeed()
        {
            return _moveSpeed;
        }
    }
}