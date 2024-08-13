using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Application.LocationSystem
{
    public class LocationSystem
    {
        private readonly Transform _worldTransform;
        private readonly Dictionary<AssetReference, AsyncOperationHandle<GameObject>> _locations = new();
        
        private LocationSystem(LocationTrigger[] locationTriggers, Transform worldTransform)
        {
            _worldTransform = worldTransform;
            
            foreach (var trigger in locationTriggers)
            {
                trigger.TriggerEntered += OnTriggerEntered;
            }
            
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnSceneUnloaded(Scene _)
        {
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
            
            foreach (var locationHandle in _locations.Values)
            {
                Addressables.Release(locationHandle);
            }
        }

        private async void OnTriggerEntered(AssetReference reference)
        {
            var handle = _locations.TryGetValue(reference, out var location) 
                ? location 
                : Addressables.LoadAssetAsync<GameObject>(reference);

            await handle.Task;
            
            _locations.Add(reference, handle);
            
            var locationObject = handle.Result;
            Object.Instantiate(locationObject, _worldTransform);
        }
    }
}