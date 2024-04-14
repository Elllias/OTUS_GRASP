using System;
using UnityEngine;

namespace Elementary
{
    public readonly struct StateTransition<T>
    {
        public readonly T stateId;

        public readonly ICondition condition;

        public StateTransition(T stateId, ICondition condition)
        {
            this.stateId = stateId;
            this.condition = condition;
        }

        public StateTransition(T stateId, Func<bool> condition)
        {
            this.stateId = stateId;
            this.condition = new ConditionDelegate(condition);
        }
    }
}