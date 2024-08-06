using System;
using UnityEngine;

namespace Game.Scripts.Application.LocationSystem
{
    public class LocationTrigger : MonoBehaviour
    {
        public event Action<int> TriggerEntered;
        
        [SerializeField] private int _locationIndex;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(_locationIndex);

            enabled = false;
        }
    }
}