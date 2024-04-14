using System.Collections.Generic;
using UnityEngine;

namespace Windows
{
    public abstract class MonoWindowSupplier<K, V> : MonoBehaviour, IWindowSupplier<K, V> where V : MonoWindow
    {
        private readonly Dictionary<K, V> cashedFrames;

        public MonoWindowSupplier()
        {
            this.cashedFrames = new Dictionary<K, V>();
        }

        public V LoadWindow(K key)
        {
            if (this.cashedFrames.TryGetValue(key, out var frame))
            {
                frame.gameObject.SetActive(true);
            }
            else
            {
                frame = this.InstantiateFrame(key);
                this.cashedFrames.Add(key, frame);
            }

            frame.transform.SetAsLastSibling();
            return frame;
        }

        public void UnloadWindow(V window)
        {
            window.gameObject.SetActive(false);
        }

        protected abstract V InstantiateFrame(K key);
    }
}