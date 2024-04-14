using System.Collections;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class AITaskCoroutine : AITask
    {
        private Coroutine coroutine;

        protected override void Do()
        {
            this.coroutine = MonoHelper.Instance.StartCoroutine(this.DoAsync());            
        }

        protected override void OnCancel()
        {
            if (this.coroutine != null)
            {
                MonoHelper.Instance.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        protected abstract IEnumerator DoAsync();
    }
}