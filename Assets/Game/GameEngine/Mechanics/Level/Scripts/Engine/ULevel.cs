using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Level/Level")]
    public sealed class ULevel : MonoBehaviour
    {
        public event Action<int> OnLevelUp;

        public event Action<int> OnLevelReset;

        public event Action<int> OnLevelSetuped;

        public event Action<int> OnMaxLevelSetuped;

        public int CurrentLevel
        {
            get { return this.currentLevel; }
        }

        public int MaxLevel
        {
            get { return this.maxLevel; }
        }

        [SerializeField]
        private int maxLevel;

        [SerializeField]
        private int currentLevel;

        [Title("Methods")]
        [GUIColor(0, 1, 0)]
        [Button]
        public void LevelUp()
        {
            if (this.currentLevel + 1 >= this.maxLevel)
            {
                Debug.LogWarning("Can't level up! Max level reached");
            }

            this.currentLevel++;
            this.OnLevelUp?.Invoke(this.currentLevel);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void ResetLevel()
        {
            this.currentLevel = 0;
            this.OnLevelReset?.Invoke(this.currentLevel);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void SetupLevel(int level)
        {
            this.currentLevel = Mathf.Clamp(level, 0, this.maxLevel);
            this.OnLevelSetuped?.Invoke(level);
        }

        [GUIColor(0, 1, 0)]
        [Button]
        public void SetupMaxLevel(int level)
        {
            if (this.currentLevel > level)
            {
                this.currentLevel = level;
            }

            this.maxLevel = level;
            this.OnMaxLevelSetuped?.Invoke(level);
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            this.maxLevel = Math.Max(1, this.maxLevel);
            this.currentLevel = Mathf.Clamp(this.currentLevel, 1, this.maxLevel);
        }
#endif
    }
}