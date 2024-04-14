using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public sealed class PlayerLevel : MonoBehaviour
    {
        public event Action<int> OnLevelUp;
        public event Action<int> OnExperienceChanged;

        [ShowInInspector]
        public int CurrentLevel /*{ get; private set; }*/ = 1;

        [ShowInInspector]
        public int CurrentExperience /*{ get; private set; }*/;

        [ShowInInspector]
        public int RequiredExperience
        {
            get { return 100 * (CurrentLevel + 1); }
        }

        [Button]
        public void AddExperience(int range)
        {
            var xp = Math.Min(CurrentExperience + range, RequiredExperience);
            CurrentExperience = xp;
            OnExperienceChanged?.Invoke(xp);
        }

        [Button]
        public void LevelUp()
        {
            if (CanLevelUp())
            {
                CurrentExperience = 0;
                CurrentLevel++;
                OnLevelUp?.Invoke(CurrentLevel);
            }
        }

        public bool CanLevelUp()
        {
            return CurrentExperience == RequiredExperience;
        }
    }
}