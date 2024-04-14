using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    public abstract class LocalizationDictionary<T> : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        public LocalizedEntity<T>[] entities;

        private Dictionary<string, LocalizedProperty<T>[]> entityMap;

        public T GetTranslation(string key, SystemLanguage language)
        {
            if (!this.entityMap.TryGetValue(key, out var entity))
            {
                return default;
            }

            if (!entity.FindValue(language, out T value))
            {
                return default;
            }

            return value;
        }

        public void OnAfterDeserialize()
        {
            this.entityMap = this.entities.ToDictionary(it => it.key, it => it.translations);
        }

        public void OnBeforeSerialize()
        {
            
        }
    }
}