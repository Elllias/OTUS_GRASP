using System.Collections;
using UnityEngine;

namespace AI.BTree
{
    public abstract class BehaviourNodeCoroutine : BehaviourNode
    {
        private Coroutine coroutine;

        protected sealed override void Run()
        {
            this.coroutine = MonoHelper.Instance.StartCoroutine(this.RunRoutine());
        }

        protected abstract IEnumerator RunRoutine();

        protected override void OnDispose()
        {
            if (this.coroutine != null)
            {
                MonoHelper.Instance.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }
    }
}