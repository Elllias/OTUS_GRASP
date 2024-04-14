using System;
using System.Collections.Generic;
using UnityEngine;

namespace Elementary
{
    public sealed class MonoStateResolver<T> : MonoBehaviour
    {
        [SerializeField]
        private MonoStateMachine<T> stateMachine;

        [SerializeField]
        private List<Transition> orderedTransitions;

        private void Update()
        {
            for (int i = 0, count = this.orderedTransitions.Count; i < count; i++)
            {
                var transition = this.orderedTransitions[i];
                if (transition.IsAvailable())
                {
                    this.stateMachine.SwitchState(transition.state);
                    return;
                }
            }
        }
        
        [Serializable]
        private struct Transition
        {
            [SerializeField]
            public MonoCondition[] conditions;

            [SerializeField]
            public T state;

            public bool IsAvailable()
            {
                for (int i = 0, count = this.conditions.Length; i < count; i++)
                {
                    var condition = this.conditions[i];
                    if (!condition.IsTrue())
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}