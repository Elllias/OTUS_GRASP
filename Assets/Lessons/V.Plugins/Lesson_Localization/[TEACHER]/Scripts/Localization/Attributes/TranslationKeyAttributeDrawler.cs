// using System;
// using System.Linq;
// using Sirenix.OdinInspector.Editor;
// using UnityEditor;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     public sealed class TranslationKeyAttributeDrawler : OdinAttributeDrawer<TranslationKeyAttribute, string>
//     {
//         protected override void DrawPropertyLayout(GUIContent label)
//         {
//             var textDictionary = Resources.Load<TextDictionary>(nameof(TextDictionary));
//             
//             var entities = textDictionary.entities;
//             if (entities == null || entities.Length <= 0)
//             {
//                 return;
//             }
//
//             var keys = entities.Select(it => it.key).ToArray();
//             var currentKey = this.ValueEntry.SmartValue;
//             
//             var index = Array.FindIndex(keys, it => it == currentKey);
//             if (index < 0)
//             {
//                 index = 0;
//             }
//             
//             index = EditorGUILayout.Popup(index, keys);
//             this.ValueEntry.SmartValue = keys[index];
//         }
//     }
// }