using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameEngine.ScriptableObjects
{
    [Serializable]
    public class UnitObjectConfig
    {
        public string Type;
        public Unit Prefab;
    }
    
    [CreateAssetMenu(fileName = "UnitsConfig", menuName = "Config/UnitsConfig", order = 0)]
    public class UnitsConfig : ScriptableObject
    {
        [SerializeField] private List<UnitObjectConfig> _configs;

        public Unit GetPrefab(string type)
        {
            var config = _configs.FirstOrDefault(config => config.Type == type);

            if (config == null)
            {
                Debug.LogError($"Config with type: {type} not exist");
                return null;
            }
            
            return config.Prefab;
        }
    }
}