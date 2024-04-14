using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    public interface ILocalizer
    {
        void Localize(SystemLanguage language);
    }
}