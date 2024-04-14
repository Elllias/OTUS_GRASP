#if UNITY_EDITOR
using UnityEditor;
using UnityEngine.UIElements;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueWindow : EditorWindow
    {
        private DialogueGraph graph;
        
        private void OnEnable()
        {
            this.AddDialogueGraph();
            this.AddToolbar();
        }

        private void AddDialogueGraph()
        {
            graph = new DialogueGraph();
            graph.StretchToParentSize();
            this.rootVisualElement.Add(graph);
        }

        private void AddToolbar()
        {
            DialogueToolbar toolbar = new DialogueToolbar(graph);
            this.rootVisualElement.Add(toolbar);
        }

        [MenuItem("Lessons/Show Dialogue Window")]
        public static void ShowDialogueWindow()
        {
            GetWindow<DialogueWindow>("Dialogue Window");
        }
    }
}
#endif