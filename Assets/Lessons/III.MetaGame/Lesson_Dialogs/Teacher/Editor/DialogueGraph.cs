// using System.Collections.Generic;
// using UnityEditor;
// using UnityEditor.Experimental.GraphView;
// using UnityEngine;
// using UnityEngine.UIElements;
//
// #if UNITY_EDITOR
//
// namespace Lessons.MetaGame.Dialogs
// {
//     public sealed class DialogueGraph : GraphView
//     {
//         private const string STYLES_PATH = "Assets/Lessons/III.MetaGame/Lesson_Dialogs/Styles/";
//
//         public DialogueGraph()
//         {
//             this.AddManipulators();
//             this.AddGridBackground();
//             this.AddStyles();
//         }
//
//         private void AddManipulators()
//         {
//             this.AddManipulator(new ContentDragger());
//             this.AddManipulator(new ContentZoomer());
//             this.AddManipulator(new ContextualMenuManipulator(this.OnMenuEvent));
//             this.AddManipulator(new RectangleSelector());
//             this.AddManipulator(new SelectionDragger());
//         }
//
//         private void AddGridBackground()
//         {
//             GridBackground background = new GridBackground();
//             background.StretchToParentSize();
//             this.Insert(0, background);
//         }
//
//         private void AddStyles()
//         {
//             this.styleSheets.Add((StyleSheet) EditorGUIUtility.Load(STYLES_PATH + "DialogueGraph.uss"));
//             this.styleSheets.Add((StyleSheet) EditorGUIUtility.Load(STYLES_PATH + "DialogueNode.uss"));
//         }
//
//         private void OnMenuEvent(ContextualMenuPopulateEvent menuPopulateEvent)
//         {
//             menuPopulateEvent.menu.AppendAction("Create Node", this.OnCreateNode);
//         }
//
//         private void OnCreateNode(DropdownMenuAction menuAction)
//         {
//             this.CreateNode(menuAction.eventInfo.mousePosition);
//         }
//
//         public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
//         {
//             var compatiblePorts = new List<Port>();
//
//             foreach (var port in this.ports)
//             {
//                 if (port == startPort)
//                 {
//                     continue;
//                 }
//
//                 if (port.node == startPort.node)
//                 {
//                     continue;
//                 }
//
//                 if (port.direction == startPort.direction)
//                 {
//                     continue;
//                 }
//
//                 compatiblePorts.Add(port);
//             }
//
//             return compatiblePorts;
//         }
//
//         public DialogueNode CreateNode(Vector2 posiiton)
//         {
//             var node = new DialogueNode(posiiton);
//             this.AddElement(node);
//             return node;
//         }
//         
//         public void CreateEdge(Port inputPort, Port outputPort)
//         {
//             var edge = new Edge
//             {
//                 output = outputPort,
//                 input = inputPort
//             };
//
//             this.AddElement(edge);
//         }
//
//         public void Reset()
//         {
//             foreach (var edge in this.edges)
//             {
//                 this.RemoveElement(edge);
//             }
//
//             foreach (var node in this.nodes)
//             {
//                 this.RemoveElement(node);
//             }
//         }
//     }
// }
//
// #endif