using System;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Lessons.Plugins.LocalizationLesson
{
    [Serializable]
    public sealed class TextLocalizer : ILocalizer
    {
        [SerializeField]
        private TMP_Text text;

        [SerializeField]
        private string textKey;

        [SerializeField]
        private bool localizeFontSize;

        void ILocalizer.Localize(SystemLanguage language)
        {
            this.text.text = LocalizationManager.GetText(this.textKey, language);
            this.text.font = LocalizationManager.GetFont(language);
            
            if (this.localizeFontSize)
            {
                this.text.fontSize = LocalizationManager.GetFontSizeMedium(language);
            }
        }
    }
}


 // [Space]
        // [SerializeField, FormerlySerializedAs("options")]
        // private LocalizedProperty<string>[] textOptions;

       