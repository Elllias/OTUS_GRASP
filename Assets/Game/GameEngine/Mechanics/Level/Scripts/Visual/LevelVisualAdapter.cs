using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Level/Level Visual Adapter")]
    public sealed class LevelVisualAdapter : MonoBehaviour
    {
        [SerializeField]
        private ULevel levelEngine;

        [SerializeField]
        private Mode mode = Mode.EQUALS;

        [Space]
        [SerializeField]
        private Level[] levels = new Level[0];

        private void OnEnable()
        {
            this.levelEngine.OnLevelSetuped += this.OnSetuped;
            this.levelEngine.OnLevelUp += this.OnLevelUp;
            this.levelEngine.OnLevelReset += this.OnResetLevel;
        }

        private void Start()
        {
            this.Setup(this.levelEngine.CurrentLevel);
        }

        private void OnDisable()
        {
            this.levelEngine.OnLevelSetuped -= this.OnSetuped;
            this.levelEngine.OnLevelUp -= this.OnLevelUp;
            this.levelEngine.OnLevelReset -= this.OnResetLevel;
        }

        private void OnSetuped(int level)
        {
            this.Setup(level);
        }

        private void OnResetLevel(int level)
        {
            this.LevelUp(level);
        }

        private void OnLevelUp(int level)
        {
            this.LevelUp(level);
        }

        private void Setup(int level)
        {
            if (this.mode == Mode.EQUALS)
            {
                for (int i = 0, count = this.levels.Length; i < count; i++)
                {
                    var levelInfo = this.levels[i];
                    var isVisible = levelInfo.number == level;
                    levelInfo.visual.SetActive(isVisible);
                }
            }
            else if (this.mode == Mode.LESS_OR_EQUALS)
            {
                for (int i = 0, count = this.levels.Length; i < count; i++)
                {
                    var levelInfo = this.levels[i];
                    var isVisible = levelInfo.number <= level;
                    levelInfo.visual.SetActive(isVisible);
                }
            }
        }

        private void LevelUp(int level)
        {
            if (this.mode == Mode.EQUALS)
            {
                for (int i = 0, count = this.levels.Length; i < count; i++)
                {
                    var levelInfo = this.levels[i];
                    if (levelInfo.number == level)
                    {
                        levelInfo.visual.Activate();
                    }
                    else
                    {
                        levelInfo.visual.SetActive(false);
                    }
                }
            }
            else if (this.mode == Mode.LESS_OR_EQUALS)
            {
                for (int i = 0, count = this.levels.Length; i < count; i++)
                {
                    var levelInfo = this.levels[i];
                    if (levelInfo.number == level)
                    {
                        levelInfo.visual.Activate();
                    }
                }
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            try
            {
                this.levelEngine.OnLevelSetuped -= this.OnSetuped;
                this.levelEngine.OnLevelSetuped += this.OnSetuped;
                this.Setup(this.levelEngine.CurrentLevel);
            }
            catch (Exception)
            {
            }
        }
#endif

        [Serializable]
        private struct Level
        {
            [SerializeField]
            public int number;

            [SerializeField]
            public LevelVisualBase visual;
        }

        private enum Mode
        {
            EQUALS = 0,
            LESS_OR_EQUALS = 1
        }
    }
}