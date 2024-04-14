// using System;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public sealed class LocalizationManager : MonoBehaviour
//     {
//         private static LocalizationManager instance;
//         
//         [SerializeField]
//         private TextDictionary textDictionary;
//     
//         private ITranslator<string> textTranslator;
//         
//         //TODO: AudioTranslator audioTranslator;
//
//         private void Awake()
//         {
//             if (instance != null)
//             {
//                 throw new Exception("Localization Manager is already exists!");
//             }
//         
//             instance = this;
//             
//             this.textTranslator = new TextTranslator(this.textDictionary.entities);
//         }
//
//         private void OnDestroy()
//         {
//             instance = null;
//         }
//
//         [Button]
//         public static string GetText(string key, SystemLanguage language)
//         {
//             if (instance != null)
//             {
//                 return instance.textTranslator.GetTraslation(key, language);                
//             }
//
//             return key;
//         }
//         
//         [Button]
//         public static AudioClip GetAudioClip(string key, SystemLanguage language)
//         {
//             return null;
//         }
//     }
// }