#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using static Game.GameEngine.UnityEditor.DialoguePaths;

namespace Game.GameEngine.UnityEditor
{
    public sealed class DialogueGraph : GraphView
    {
        public int generatedId;
        
        public DialogueGraph()
        {
            this.InitStyles();
            this.InitManipulators();
            this.InitGridBackground();
        }

        private void InitStyles()
        {
            this.styleSheets.Add((StyleSheet) EditorGUIUtility.Load(FOLDER_PATH + "Styles/DialogueGraph.uss"));
            this.styleSheets.Add((StyleSheet) EditorGUIUtility.Load(FOLDER_PATH + "Styles/DialogueNode.uss"));
        }

        private void InitManipulators()
        {
            this.AddManipulator(new ContextualMenuManipulator(this.OnMenuEvent));
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new ContentZoomer());
        }

        private void InitGridBackground()
        {
            GridBackground gridBackground = new GridBackground();
            gridBackground.StretchToParentSize();

            Insert(0, gridBackground);
        }

        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            var compatiblePorts = new List<Port>();
            foreach (var port in ports)
            {
                if (port != startPort &&
                    port.node != startPort.node &&
                    startPort.direction != port.direction)
                {
                    compatiblePorts.Add(port);
                }
            }

            return compatiblePorts;
        }

        private void OnMenuEvent(ContextualMenuPopulateEvent menuEvent)
        {
            menuEvent.menu.AppendAction("Add Node", AddNode);
            
            if (menuEvent.target is DialogueNode selectedNode)
            {

                menuEvent.menu.AppendAction("Set As Entry", _ => SetAsEntry(selectedNode));
            }
        }

        private void AddNode(DropdownMenuAction actionEvent)
        {
            var screenPosition = actionEvent.eventInfo.localMousePosition;
            var node = DialogueNode.Instantiate(screenPosition);
            node.Id = this.generatedId++;
            this.AddElement(node);
            
            var list = this.nodes.ToList();
            if (list.Count == 1)
            {
                node.SetAsEntry();
            }
            else
            {
                node.SetAsNotEntry();
            }
        }

        private void SetAsEntry(DialogueNode targetNode)
        {
            targetNode.SetAsEntry();

            foreach (var node in this.nodes)
            {
                if (node != targetNode && node is DialogueNode dialogueNode)
                {
                    dialogueNode.SetAsNotEntry();
                }
            }
        }

        public DialogueNode GetEntryNode()
        {
            foreach (var node in this.nodes)
            {
                var dialogueNode = (DialogueNode) node;
                if (dialogueNode.IsEntry)
                {
                    return dialogueNode;
                }
            }

            throw new Exception("Entry node is not found!");
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