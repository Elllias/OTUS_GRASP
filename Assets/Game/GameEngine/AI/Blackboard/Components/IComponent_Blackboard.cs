using System.Collections.Generic;

namespace Game.GameEngine.AI
{
    public interface IComponent_Blackboard
    {
        T GetVariable<T>(string key);

        IEnumerable<KeyValuePair<string, object>> GetVariables();

        bool TryGetVariable<T>(string key, out T value);

        bool HasVariable(string key);

        void AddVariable(string key, object value);

        void ChangeVariable(string key, object value);

        void RemoveVariable(string key);

        void Clear();
    }
}