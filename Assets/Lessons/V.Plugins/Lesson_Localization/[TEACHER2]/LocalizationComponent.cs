// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public sealed class LocalizationComponent : MonoBehaviour
//     {
//         [SerializeReference]
//         private ILocalizer[] listeners = new ILocalizer[0];
//
//         private void OnEnable()
//         {
//             this.UpdateLanguage(LanguageManager.Language);
//             LanguageManager.OnLanguageChanged += this.UpdateLanguage;
//         }
//
//         private void OnDisable()
//         {
//             LanguageManager.OnLanguageChanged -= this.UpdateLanguage;
//         }
//
//         private void UpdateLanguage(SystemLanguage language)
//         {
//             for (int i = 0, count = this.listeners.Length; i < count; i++)
//             {
//                 var listener = this.listeners[i];
//                 listener.Localize(language);
//             }
//         }
//     }
// }