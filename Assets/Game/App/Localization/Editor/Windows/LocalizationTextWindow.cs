#if UNITY_EDITOR
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Game.Localization.UnityEditor
{
    public sealed class LocalizationTextWindow : EditorWindow
    {
        private SerializedObject serializedObject;

        private SerializedProperty spreadsheet;

        private LocalizationTextConfig config;

        private int toolbarIndex;

        private Vector2 scrollPosition;

        private void OnEnable()
        {
            this.titleContent = new GUIContent("Localization Texts");
            this.config = Configs.TextConfig;
            this.serializedObject = new SerializedObject(this.config);
            this.spreadsheet = this.serializedObject.FindProperty(nameof(this.spreadsheet));
        }

        private void OnGUI()
        {
            var pageNames = this.GetPageNames();
            if (pageNames.Length <= 0)
            {
                return;
            }

            this.toolbarIndex = GUILayout.Toolbar(this.toolbarIndex, pageNames);

            EditorGUILayout.Space(8);
            EditorGUILayout.BeginVertical();
            this.scrollPosition = EditorGUILayout.BeginScrollView(
                this.scrollPosition,
                GUILayout.ExpandWidth(true),
                GUILayout.ExpandHeight(true)
            );
            
            var pages = this.spreadsheet.FindPropertyRelative("pages");
            var page = pages.GetArrayElementAtIndex(this.toolbarIndex);

            var entities = page.FindPropertyRelative("entities");
            EditorGUILayout.PropertyField(entities, includeChildren: true);
            
            this.serializedObject.ApplyModifiedProperties();

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();
        }

        private string[] GetPageNames()
        {
            return this.config.spreadsheet.pages
                .Select(it => it.name)
                .ToArray();
        }
    }
}
#endif