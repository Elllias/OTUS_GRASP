using System.Collections.Generic;
using AI.Blackboards;

namespace Game.GameEngine.AI
{
    public sealed class Component_Blackboard : IComponent_Blackboard
    {
        private readonly IBlackboard blackboard;

        public Component_Blackboard(IBlackboard blackboard)
        {
            this.blackboard = blackboard;
        }

        public T GetVariable<T>(string key)
        {
            return this.blackboard.GetVariable<T>(key);
        }

        public IEnumerable<KeyValuePair<string, object>> GetVariables()
        {
            return this.blackboard.GetVariables();
        }

        public bool TryGetVariable<T>(string key, out T value)
        {
            return this.blackboard.TryGetVariable(key, out value);
        }

        public bool HasVariable(string key)
        {
            return this.blackboard.HasVariable(key);
        }

        public void AddVariable(string key, object value)
        {
            this.blackboard.AddVariable(key, value);
        }

        public void ChangeVariable(string key, object value)
        {
            this.blackboard.ChangeVariable(key, value);
        }

        public void RemoveVariable(string key)
        {
            this.blackboard.RemoveVariable(key);
        }

        public void Clear()
        {
            this.blackboard.Clear();
        }
    }
}