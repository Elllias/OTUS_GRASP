using System;

namespace Game.GameEngine.Mechanics
{
    public interface IComponent_GetLevel
    {
        int Level { get; }
    }
    
    public interface IComponent_SetupLevel
    {
        void SetupLevel(int level);
    }

    public interface IComponent_OnLevelSetupped
    {
        event Action<int> OnLevelSetuped;
    }
    
    public interface IComponent_LevelUp
    {
        void LevelUp();
    }
    
    public interface IComponent_OnLevelUp
    {
        public event Action<int> OnLevelUp;
    }
    
    public interface IComponent_ResetLevel
    {
        void ResetLevel();
    }

    public interface IComponent_OnLevelReset
    {
        event Action<int> OnLevelReset;
    }
    
    public interface IComponent_GetMaxLevel
    {
        int MaxLevel { get; }
    }
}