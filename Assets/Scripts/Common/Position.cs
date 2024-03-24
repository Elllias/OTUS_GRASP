using System;
using UnityEngine;

namespace Common
{
    public class Position : MonoBehaviour
    {
        public event Action<Position> Released;
        
        public void Release()
        {
            Released?.Invoke(this);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}