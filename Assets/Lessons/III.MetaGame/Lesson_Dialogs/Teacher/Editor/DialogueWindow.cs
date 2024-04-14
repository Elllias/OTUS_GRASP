// #if UNITY_EDITOR
// using UnityEditor;
// using UnityEngine.UIElements;
//
// namespace Lessons.MetaGame.Dialogs
// {
//     public sealed class DialogueWindow : EditorWindow
//     {
//         private DialogueGraph graph;
//         private DialogueToolbar toolbar;
//         
//         [MenuItem("Lessons/Dialogue Window")]
//         public static void ShowWindow()
//         {
//             GetWindow<DialogueWindow>("Dialogue Window");
//         }
//
//         private void OnEnable()
//         {
//             this.AddGraphView();
//             this.AddToolbar();
//         }
//
//         private void AddGraphView()
//         {
//             this.graph = new DialogueGraph();
//             this.graph.StretchToParentSize();
//             this.rootVisualElement.Add(this.graph);
//         }
//
//         private void AddToolbar()
//         {
//             this.toolbar = new DialogueToolbar(this.graph);
//             this.rootVisualElement.Add(this.toolbar);
//         }
//     }
// }
// #endif