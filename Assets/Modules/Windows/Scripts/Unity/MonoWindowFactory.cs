using UnityEngine;

namespace Windows
{
    public abstract class MonoWindowFactory<K, V> : MonoBehaviour, IWindowFactory<K, V> where V : MonoWindow
    {
        [SerializeField]
        private Transform container;

        public V CreateWindow(K key)
        {
            var prefab = this.GetPrefab(key);
            var popup = Instantiate(prefab, this.container);
            this.OnFrameCreated(popup);
            return popup;
        }

        protected abstract V GetPrefab(K key);

        protected virtual void OnFrameCreated(V popup)
        {
        }
    }
}