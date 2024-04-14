// using Sirenix.OdinInspector.Editor;
// using Unity.EditorCoroutines.Editor;
// using UnityEditor;
// using UnityEngine;
//
// namespace Lessons.Plugins.LocalizationLesson
// {
//     [CustomEditor(typeof(TextDictionary))]
//     public sealed class TextDictionaryEditor : OdinEditor
//     {
//         private TextDictionary config;
//     
//         protected override void OnEnable()
//         {
//             base.OnEnable();
//             this.config = this.serializedObject.targetObject as TextDictionary;
//         }
//
//         public override void OnInspectorGUI()
//         {
//             base.OnInspectorGUI();
//
//             GUILayout.Space(8);
//             if (GUILayout.Button("Update Dictionary"))
//             {
//                 EditorCoroutineUtility.StartCoroutineOwnerless(TextDictionaryUpdater.UpdateDictinaryRoutine(this.config));
//             }
//         }
//     }
// }