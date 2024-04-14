using System;
using UnityEngine;

namespace Game.GameEngine.Mechanics
{
    [AddComponentMenu("GameEngine/Mechanics/Level/Component «Level»")]
    public sealed class UComponent_Level : MonoBehaviour,
        IComponent_GetLevel,
        IComponent_SetupLevel,
        IComponent_LevelUp,
        IComponent_GetMaxLevel,
        IComponent_ResetLevel
    {
        public event Action<int> OnLevelUp
        {
            add { this.levelEngine.OnLevelUp += value; }
            remove { this.levelEngine.OnLevelUp -= value; }
        }

        public event Action<int> OnLevelSetuped
        {
            add { this.levelEngine.OnLevelSetuped += value; }
            remove { this.levelEngine.OnLevelSetuped -= value; }
        }

        public event Action<int> OnLevelReset
        {
            add { this.levelEngine.OnLevelReset += value; }
            remove { this.levelEngine.OnLevelReset -= value; }
        }

        public int Level
        {
            get { return this.levelEngine.CurrentLevel; }
        }

        public int MaxLevel
        {
            get { return this.levelEngine.MaxLevel; }
        }

        [SerializeField]
        private ULevel levelEngine;

        public void SetupLevel(int level)
        {
            this.levelEngine.SetupLevel(level);
        }

        public void LevelUp()
        {
            this.levelEngine.LevelUp();
        }

        public void ResetLevel()
        {
            this.levelEngine.ResetLevel();
        }
    }
}