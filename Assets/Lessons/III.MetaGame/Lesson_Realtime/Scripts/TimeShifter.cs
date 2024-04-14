using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class TimeShifter : MonoBehaviour
    {
        private readonly List<ITimeShiftListener> listeners = new();

        [Button]
        public void ShiftTime(float secondOffset)
        {
            foreach (var listener in this.listeners)
            {
                listener.OnTimeShifted(secondOffset);
            }

            Debug.Log($"On Time Shifted! {secondOffset}");
        }

        public void AddListener(ITimeShiftListener listener)
        {
            this.listeners.Add(listener);
        }

        public void RemoveListener(ITimeShiftListener listener)
        {
            this.listeners.Remove(listener);
        }
    }
}