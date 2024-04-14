using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class TimeShiftEmitter : MonoBehaviour
    {
        public event TimeShiftDelegate OnTimeShifted;
        
        [SerializeField]
        private bool isEnable = true;

        private readonly List<ITimeShiftHandler> handlers = new();

        [Button]
        [ShowIf("isEnable")]
        [GUIColor(0, 1, 0)]
        public void EmitEvent(TimeShiftReason reason, float shiftSeconds)
        {
            if (!this.isEnable)
            {
                return;
            }

            for (int i = 0, count = this.handlers.Count; i < count; i++)
            {
                var listener = this.handlers[i];
                listener.OnTimeShifted(reason, shiftSeconds);
            }

            this.OnTimeShifted?.Invoke(reason, shiftSeconds);
        }

        public void AddHandler(ITimeShiftHandler handler)
        {
            this.handlers.Add(handler);
        }

        public void RemoveHandler(ITimeShiftHandler handler)
        {
            this.handlers.Remove(handler);
        }
    }
}