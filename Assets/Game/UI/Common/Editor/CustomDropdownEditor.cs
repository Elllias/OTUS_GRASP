#if UNITY_EDITOR
using UnityEditor;

namespace Game.App.QualitySettings.Editor
{
    [CustomEditor(typeof(CustomDropdown))]
    public class CustomDropdownEditor : TMPro.EditorUtilities.DropdownEditor
    {
        SerializedProperty blocker;

        protected override void OnEnable()
        {
            base.OnEnable();
            this.blocker = serializedObject.FindProperty("blocker");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.PropertyField(blocker);
            serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif
