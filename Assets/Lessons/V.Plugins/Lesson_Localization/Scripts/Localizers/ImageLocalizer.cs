using System;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Plugins.LocalizationLesson
{
    [Serializable]
    public sealed class ImageLocalizer : ILocalizer
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private string imageKey;

        void ILocalizer.Localize(SystemLanguage language)
        {
            this.image.sprite = LocalizationManager.GetSprite(this.imageKey, language);
        }
    }
}

// this.options.FindValue(language)
// [SerializeField]
// private LocalizedProperty<Sprite>[] options;
