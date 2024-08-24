using System.Collections.Generic;
using UnityEngine.Pool;

namespace Systems
{
    public class CooldownSystem
    {
        private readonly Dictionary<int, float> _entityCooldownDictionary = new();

        public void Add(int entityId, float cooldown)
        {
            if (_entityCooldownDictionary.ContainsKey(entityId)) return;

            _entityCooldownDictionary.Add(entityId, cooldown);
        }

        public void Remove(int entityId)
        {
            if (!_entityCooldownDictionary.ContainsKey(entityId)) return;

            _entityCooldownDictionary.Remove(entityId);
        }

        public void Update(float deltaTime)
        {
            ListPool<int>.Get(out var keys);

            foreach (var key in _entityCooldownDictionary.Keys)
            {
                keys.Add(key);
            }

            foreach (var key in keys)
            {
                _entityCooldownDictionary[key] -= deltaTime;
            }

            ListPool<int>.Release(keys);
        }

        public bool IsEntityCooldownInProgress(int entityId)
        {
            if (!_entityCooldownDictionary.TryGetValue(entityId, out var entityCooldown)) return false;

            return entityCooldown > 0;
        }
    }
}