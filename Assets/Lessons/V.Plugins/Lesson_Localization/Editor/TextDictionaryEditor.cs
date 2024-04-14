#if UNITY_EDITOR

using Lessons.Plugins.LocalizationLesson;
using Unity.EditorCoroutines.Editor;
using UnityEditor;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Localization
{
    [CustomEditor(typeof(TextDictionary))]
    public sealed class TextDictionaryEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Sync"))
            {
                var textDictionary = this.target as TextDictionary;
                var updateRoutine = TextDictionaryUpdater.UpdateDictionaryRoutine(textDictionary);
                EditorCoroutineUtility.StartCoroutineOwnerless(updateRoutine);
            }
        }
    }
}
#endif