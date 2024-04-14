using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.AI.Architecture
{
    public abstract class Task : MonoBehaviour
    {
        [ShowInInspector, ReadOnly]
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private bool isPlaying;

        private ITaskCallback callback;

        [Button]
        public void Do(ITaskCallback callback)
        {
            if (this.isPlaying)
            {
                Debug.LogWarning($"Action {this.name} is already started!");
                return;
            }

            this.isPlaying = true;
            this.callback = callback;
            this.Do();
        }

        [Button]
        public void Cancel()
        {
            if (!this.isPlaying)
            {
                return;
            }

            this.isPlaying = false;
            this.callback = null;
            this.OnCancel();
        }
        
        protected abstract void Do();

        protected void Return(bool success)
        {
            this.isPlaying = false;
            var callback = this.callback;
            callback?.OnComplete(this, success);
            this.callback = null;
        }

        protected virtual void OnCancel()
        {
        }
    }
}