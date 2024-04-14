#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueGraph : GraphView
    {
        public DialogueGraph()
        {
            this.AddBackground();
            this.AddStyles();
            this.AddManipulators();
        }

        private void AddManipulators()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new ContextualMenuManipulator(this.OnMenuEvent));
        }

        private void OnMenuEvent(ContextualMenuPopulateEvent menuEvent)
        {
            menuEvent.menu.AppendAction("Create Node", this.OnCreateNode);
        }

        private void AddBackground()
        {
            GridBackground background = new GridBackground();
            background.StretchToParentSize();
            this.Insert(0, background);
        }

        private void AddStyles()
        {
            StyleSheet graphStyle = (StyleSheet) EditorGUIUtility.Load(
                "Assets/Lessons/III.MetaGame/Lesson_Dialogs/Styles/DialogueGraph.uss"
            );

            StyleSheet nodeStyle = (StyleSheet) EditorGUIUtility.Load(
                "Assets/Lessons/III.MetaGame/Lesson_Dialogs/Styles/DialogueNode.uss"
            );

            this.styleSheets.Add(graphStyle);
            this.styleSheets.Add(nodeStyle);
        }

        private void OnCreateNode(DropdownMenuAction menuAction)
        {
            var nodePosition = menuAction.eventInfo.localMousePosition;
            this.CreateNode(nodePosition);
        }

        public DialogueNode CreateNode(Vector2 position)
        {
            DialogueNode node = new DialogueNode();
            node.SetPosition(new Rect(position, Vector2.zero));
            this.AddElement(node);
            return node;
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();

            foreach (var port in this.ports)
            {
                if (port == startPort)
                {
                    continue;
                }

                if (port.node == startPort.node)
                {
                    continue;
                }

                if (port.direction == startPort.direction)
                {
                    continue;
                }

                compatiblePorts.Add(port);
            }

            return compatiblePorts;
        }

        public void CreateEdge(Port inputPort, Port outputPort)
        {
            Edge edge = new Edge
            {
                input = inputPort,
                output = outputPort
            };
            this.AddElement(edge);
        }

        public void Reset()
        {
            foreach (var edge in this.edges)
            {
                this.RemoveElement(edge);
            }

            foreach (var node in this.nodes)
            {
                this.RemoveElement(node);
            }
        }
    }
}
#endif