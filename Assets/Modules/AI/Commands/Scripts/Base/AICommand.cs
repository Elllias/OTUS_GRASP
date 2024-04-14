using UnityEngine;

namespace AI.Commands
{
    public abstract class AICommand : IAICommand
    {
        public bool IsPlaying
        {
            get { return this.isPlaying; }
        }

        private bool isPlaying;

        private IAICommandCallback callback;

        private object args;

        public void Execute(object args, IAICommandCallback callback)
        {
            if (this.isPlaying)
            {
                Debug.LogWarning($"Command {this.GetType().Name} is already started!");
                return;
            }

            this.args = args;
            this.callback = callback;
            this.isPlaying = true;
            this.Execute(args);
        }

        public void Interrupt()
        {
            if (!this.isPlaying)
            {
                return;
            }

            this.OnInterrupt();
            this.isPlaying = false;
            this.args = null;
            this.callback = null;
        }
        
        protected abstract void Execute(object args);

        protected void Return(bool success)
        {
            this.isPlaying = false;
            
            var callback = this.callback;
            this.callback = null;

            var args = this.args;
            this.args = null;

            callback?.Invoke(this, args, success);
        }

        protected virtual void OnInterrupt()
        {
        }
    }

    public abstract class AICommand<T> : AICommand
    {
        protected sealed override void Execute(object args)
        {
            if (args is not T tArgs)
            {
                Debug.LogWarning("Mismatch command type");
                this.Return(false);
                return;
            }
            
            this.Execute(tArgs);
        }

        protected abstract void Execute(T args);
    }
}