using System;

namespace Lessons.Plugins.LocalizationLesson
{
    [Serializable]
    public struct LocalizedEntity<T>
    {
        public string key;
        public LocalizedProperty<T>[] translations;
    }
}