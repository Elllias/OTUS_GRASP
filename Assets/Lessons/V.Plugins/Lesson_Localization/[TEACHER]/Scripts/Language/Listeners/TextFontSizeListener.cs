// using System;
// using TMPro;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     [Serializable]
//     public sealed class TextFontSizeListener : ILanguageListener
//     {
//         [SerializeField]
//         private TextMeshProUGUI text;
//
//         [SerializeField]
//         private LocalizedInt[] options;
//         
//         public void OnLanguageChanged(SystemLanguage language)
//         {
//             if (this.options.FindValue(language, out var fontSize))
//             {
//                 this.text.fontSize = fontSize;
//             }
//         }
//     }
// }