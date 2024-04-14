using System;
using System.Collections;
using UnityEngine;

namespace AI.BTree
{
    [Serializable]
    public class BehaviourNode_WaitForSeconds : BehaviourNodeCoroutine
    {
        [SerializeField]
        public float waitSeconds;

        protected override IEnumerator RunRoutine()
        {
            yield return new WaitForSeconds(this.waitSeconds);
            this.Return(true);
        }
    }
}