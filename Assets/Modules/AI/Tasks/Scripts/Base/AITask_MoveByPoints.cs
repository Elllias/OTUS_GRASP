using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Tasks
{
    public abstract class AITask_MoveByPoints<T> : AITaskCoroutine
    {
        private readonly List<T> currentPath = new();

        private YieldInstruction framePeriod;

        public void SetFramePeriod(YieldInstruction framePeriod)
        {
            this.framePeriod = framePeriod;
        }

        public void SetPath(IEnumerable<T> points)
        {
            this.currentPath.Clear();
            this.currentPath.AddRange(points);
        }

        protected override IEnumerator DoAsync()
        {
            for (var i = 0; i < this.currentPath.Count; i++)
            {
                var nextPoint = this.currentPath[i];
                yield return this.MoveToNextPoint(nextPoint);
            }

            yield return this.framePeriod;
            this.Return(true);
        }

        private IEnumerator MoveToNextPoint(T target)
        {
            while (!this.CheckPointReached(target))
            {
                this.MoveToPoint(target);
                yield return this.framePeriod;
            }
        }

        protected abstract bool CheckPointReached(T target);

        protected abstract void MoveToPoint(T target);
    }
}