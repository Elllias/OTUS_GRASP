using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _poolContainer;
        private readonly Transform _parentTransform;
        private readonly Queue<T> _queue;

        public Pool(T prefab, Transform poolContainer, Transform parentTransform)
        {
            _queue = new Queue<T>();

            _prefab = prefab;
            _poolContainer = poolContainer;
            _parentTransform = parentTransform;
        }

        public T Get(Vector3 position, Quaternion rotation)
        {
            if (_queue.TryDequeue(out var obj))
            {
                obj.transform.SetParent(_parentTransform);
                obj.transform.SetPositionAndRotation(position, rotation);
                
                return obj;
            }

            obj = Object.Instantiate(_prefab, position, rotation, _parentTransform);
            
            return obj;
        }

        public void Release(T obj)
        {
            _queue.Enqueue(obj);
            obj.transform.SetParent(_poolContainer);
        }
    }
}