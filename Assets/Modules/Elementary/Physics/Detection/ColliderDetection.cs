using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Elementary
{
    public abstract class ColliderDetection : MonoBehaviour
    {
        public event Action OnCollidersUpdated;

        [Space]
        [SerializeField]
        [FormerlySerializedAs("playOnAwake")]
        private bool playOnStart;
        
        [Space]
        [SerializeField]
        private float minScanPeriod = 0.1f;

        [SerializeField]
        private float maxScanPeriod = 0.2f;

        [Space]
        [SerializeField]
        private int bufferCapacity = 64;

        [Title("Debug")]
        [PropertyOrder(10)]
        [ReadOnly]
        [ShowInInspector]
        public bool IsPlaying
        {
            get { return this.coroutine != null; }
        }

        [PropertyOrder(11)]
        [ReadOnly]
        [ShowInInspector]
        private Collider[] buffer;

        private int bufferSize;

        private Coroutine coroutine;

        private readonly List<IColliderDetectionHandler> listeners = new();
        
        private void Start()
        {
            this.buffer = new Collider[this.bufferCapacity];
            if (this.playOnStart)
            {
                this.Play();
            }
        }

        public void GetCollidersNonAlloc(Collider[] buffer, out int size)
        {
            size = this.bufferSize;
            Array.Copy(this.buffer, buffer, size);
        }

        public void GetCollidersUnsafe(out Collider[] buffer, out int size)
        {
            buffer = this.buffer;
            size = this.bufferSize;
        }

        public void Play()
        {
            if (this.coroutine == null)
            {
                this.coroutine = this.StartCoroutine(this.UpdateColliders());
            }
        }

        public void Stop()
        {
            if (this.coroutine != null)
            {
                this.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        public void AddListener(IColliderDetectionHandler handler)
        {
            this.listeners.Add(handler);
        }

        public void RemoveListener(IColliderDetectionHandler handler)
        {
            this.listeners.Remove(handler);
        }

        private IEnumerator UpdateColliders()
        {
            while (true)
            {
                var period = Random.Range(this.minScanPeriod, this.maxScanPeriod);
                yield return new WaitForSeconds(period);

                Array.Clear(this.buffer, 0, this.buffer.Length);
                this.bufferSize = this.Detect(this.buffer);
                
                this.InvokeCollidersUpdated(this.bufferSize, this.buffer);
            }
        }

        private void InvokeCollidersUpdated(int size, Collider[] buffer)
        {
            for (int i = 0, count = this.listeners.Count; i < count; i++)
            {
                var listener = this.listeners[i];
                listener.OnCollidersUpdated(buffer, size);
            }
            
            this.OnCollidersUpdated?.Invoke();
        }

        protected abstract int Detect(Collider[] buffer);
    }
}