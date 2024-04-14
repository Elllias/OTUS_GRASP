// using System;
// using TMPro;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     // [Serializable]
//     // public sealed class TextLanguageListener : ILanguageListener //  Потом переписать на получение значения из словаря
//     // {
//     //     [SerializeField]
//     //     private TextMeshProUGUI text;
//     //
//     //     [SerializeField]
//     //     private LocalizedString[] options;
//     //     
//     //     void ILanguageListener.OnLanguageChanged(SystemLanguage language)
//     //     {
//     //         if (this.options.FindValue(language, out var translation))
//     //         {
//     //             this.text.text = translation;
//     //         }
//     //     }
//     // }
//     
//     [Serializable]
//     public sealed class TextLanguageListener : ILanguageListener //  Потом переписать на получение значения из словаря
//     {
//         [SerializeField]
//         private TextMeshProUGUI text;
//
//         [TranslationKey]
//         [SerializeField]
//         private string key;
//     
//         void ILanguageListener.OnLanguageChanged(SystemLanguage language)
//         {
//             this.text.text = LocalizationManager.GetText(this.key, language);
//         }
//     }
// }