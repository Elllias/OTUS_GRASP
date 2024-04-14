using UnityEngine;

namespace AI.Tasks
{
    public abstract class AITask : IAITask
    {
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private bool isPlaying;

        private IAITaskCallback callback;

        public void Do(IAITaskCallback callback)
        {
            if (this.isPlaying)
            {
                Debug.LogWarning($"Task {this.GetType().Name} is already started!");
                return;
            }

            this.isPlaying = true;
            this.callback = callback;
            this.Do();
        }

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
            this.callback = null;

            callback?.Invoke(this, success);
        }

        protected virtual void OnCancel()
        {
        }
    }
}