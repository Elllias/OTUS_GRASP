using System.Collections;
using UnityEngine;

namespace AI.BTree
{
    [AddComponentMenu(Extensions.MENU_PATH + "Node «Wait For Seconds»")]
    public sealed class UnityBehaviourNode_WaitForSeconds : UnityBehaviourNode_Coroutine
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