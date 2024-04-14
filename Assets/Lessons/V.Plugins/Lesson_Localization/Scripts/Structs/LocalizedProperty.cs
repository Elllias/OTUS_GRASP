using System;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    [Serializable]
    public struct LocalizedProperty<T>
    {
        public SystemLanguage language;
        public T value;
    }

    public static class LocalizedPropertyExtensions
    {
        public static T FindValue<T>(this LocalizedProperty<T>[] options, SystemLanguage language)
        {
            foreach (var option in options)
            {
                if (option.language == language)
                {
                    return option.value;
                }
            }

            throw new Exception($"Option {language} is not found!");
        }
        
        public static bool FindValue<T>(this LocalizedProperty<T>[] options, SystemLanguage language, out T value)
        {
            foreach (var option in options)
            {
                if (option.language == language)
                {
                    value = option.value;
                    return true;
                }
            }

            value = default;
            return false;
        }
    }
}