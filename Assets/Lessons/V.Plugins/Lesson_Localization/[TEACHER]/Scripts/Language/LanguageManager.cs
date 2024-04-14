// using System;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public sealed class LanguageManager : MonoBehaviour
//     {
//         public static event Action<SystemLanguage> OnLanguageChanged;
//
//         public static SystemLanguage Language
//         {
//             get { return GetLanguage(); }
//             set { SetLanguage(value); }
//         }
//
//         private static LanguageManager instance;
//
//         [ShowInInspector, OnValueChanged("SetLanguageEditor")]
//         private SystemLanguage language;
//
//         private void Awake()
//         {
//             if (instance != null)
//             {
//                 throw new Exception("Language Manager is already exists!");
//             }
//
//             instance = this;
//
//             var initialLanguage = Application.systemLanguage;
//             this.language = initialLanguage;
//             OnLanguageChanged?.Invoke(initialLanguage);
//         }
//
//         private void OnDestroy()
//         {
//             instance = null;
//         }
//
//         private static SystemLanguage GetLanguage()
//         {
//             if (instance != null)
//             {
//                 return instance.language;
//             }
//
//             return default;
//         }
//
//         private static void SetLanguage(SystemLanguage language)
//         {
//             if (instance != null)
//             {
//                 instance.language = language;
//                 OnLanguageChanged?.Invoke(language);
//             }
//         }
//
//
// #if UNITY_EDITOR
//         private void SetLanguageEditor(SystemLanguage language)
//         {
//             this.language = language;
//             OnLanguageChanged?.Invoke(language);
//         }
// #endif
//     }
// }