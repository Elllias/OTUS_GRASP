#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Game.Localization.UnityEditor
{
    public sealed class LocalizationAudioClipWindow : EditorWindow
    {
        private SerializedObject serializedObject;

        private SerializedProperty entities;

        private Vector2 scrollPosition;

        private void OnEnable()
        {
            this.titleContent = new GUIContent("Localization Audio Clips");
            this.serializedObject = new SerializedObject(Configs.AudioClipConfig);
            this.entities = this.serializedObject.FindProperty("entities");
        }

        private void OnGUI()
        {
            EditorGUILayout.Space(8);

            EditorGUILayout.BeginVertical();
            this.scrollPosition = EditorGUILayout.BeginScrollView(
                this.scrollPosition,
                GUILayout.ExpandWidth(true),
                GUILayout.ExpandHeight(true)
            );
            
            EditorGUILayout.PropertyField(this.entities, includeChildren: true);
            this.serializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }
    }
}
#endif