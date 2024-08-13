using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Game.Scripts.Application.LocationSystem
{
    public class LocationTrigger : MonoBehaviour
    {
        public event Action<AssetReference> TriggerEntered;
        
        [SerializeField] private AssetReference _reference;

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(_reference);

            enabled = false;
        }
    }
}