// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public sealed class TextTranslator : ITranslator<string>
//     {
//         private readonly Dictionary<string, TextEntity> entities;
//
//         public TextTranslator(TextEntity[] entities)
//         {
//             this.entities = new Dictionary<string, TextEntity>();
//             foreach (var entity in entities)
//             {
//                 this.entities[entity.key] = entity;
//             }
//         }
//
//         public string GetTraslation(string key, SystemLanguage language)
//         {
//             if (!this.entities.TryGetValue(key, out var entity))
//             {
//                 Debug.LogWarning($"Entity {key} is not found!");
//                 return key;
//             }
//
//             if (!entity.translations.FindValue(language, out var traslation))
//             {
//                 Debug.LogWarning($"Translation {key} {language} is not found!");
//                 return key;
//             }
//
//             return traslation;
//         }
//     }
// }