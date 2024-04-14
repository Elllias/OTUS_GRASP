#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Game.Tutorial.UnityEditor
{
    [CustomEditor(typeof(TutorialManager))]
    public sealed class TutorialManagerEditor : Editor
    {
        private SerializedProperty stepList;

        private TutorialManager manager;

        private void Awake()
        {
            this.stepList = this.serializedObject.FindProperty(nameof(this.stepList));
            this.manager = (TutorialManager) this.target;
        }

        public override void OnInspectorGUI()
        {
            if (EditorApplication.isPlaying)
            {
                GUI.enabled = false;
                EditorGUILayout.Toggle("Completed", this.manager.IsCompleted);
                EditorGUILayout.EnumPopup("Current Step", this.manager.CurrentStep);
                GUI.enabled = true;
                
                EditorGUILayout.Space(8);
                if (GUILayout.Button("Move Next"))
                {
                    this.manager.FinishCurrentStep();
                    this.manager.MoveToNextStep();
                }
            }
            
            EditorGUILayout.Space(4.0f);
            EditorGUILayout.PropertyField(this.stepList, includeChildren: true);

            this.serializedObject.ApplyModifiedProperties();
        }
    }
}
#endif