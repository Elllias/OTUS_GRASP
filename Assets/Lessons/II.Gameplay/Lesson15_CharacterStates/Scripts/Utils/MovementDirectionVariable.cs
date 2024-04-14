using System;
using UnityEngine;

namespace Lessons.Utils
{
    [Serializable]
    public sealed class MovementDirectionVariable : AtomicVariable<Vector3>
    {
        public AtomicEvent MovementStarted { get; set; } = new();
        public AtomicEvent MovementFinished { get; set; } = new();

        protected override void SetValue(Vector3 value)
        {
            var previousValue = Value;
            base.SetValue(value);

            var isPreviousValueZero = previousValue == Vector3.zero;
            var isCurrentValueZero = Value == Vector3.zero;

            if (isPreviousValueZero && !isCurrentValueZero)
            {
                MovementStarted?.Invoke();
            }

            if (!isPreviousValueZero && isCurrentValueZero)
            {
                MovementFinished?.Invoke();
            }
        }
    }
}