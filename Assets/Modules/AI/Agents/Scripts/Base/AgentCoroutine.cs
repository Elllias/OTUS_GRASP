using System.Collections;
using UnityEngine;

namespace AI.Agents
{
    public abstract class AgentCoroutine : Agent
    {
        private YieldInstruction framePeriod;

        private Coroutine coroutine;

        public void SetFramePeriod(YieldInstruction framePeriod)
        {
            this.framePeriod = framePeriod;
        }

        protected override void OnStart()
        {
            this.coroutine = MonoHelper.Instance.StartCoroutine(this.LoopCoroutine());
        }

        protected override void OnStop()
        {
            if (this.coroutine != null)
            {
                MonoHelper.Instance.StopCoroutine(this.coroutine);
                this.coroutine = null;
            }
        }

        private IEnumerator LoopCoroutine()
        {
            while (true)
            {
                yield return this.framePeriod;
                this.Update();
            }
        }

        protected abstract void Update();
    }
}