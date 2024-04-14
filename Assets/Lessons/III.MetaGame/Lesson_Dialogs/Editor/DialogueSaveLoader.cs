#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Lessons.MetaGame.Dialogs
{
    public sealed class DialogueSaveLoader
    {
        public static void LoadDialog(DialogueConfig config, DialogueGraph graphView)
        {
            if (config == null)
            {
                Debug.LogWarning("Dialog is null!");
                return;
            }

            var nodes = new List<DialogueNode>();
            foreach (var serializedNode in config.nodes)
            {
                var node = graphView.CreateNode(serializedNode.editorPosition);
                node.Id = serializedNode.id;
                node.Message = serializedNode.message;

                foreach (var serializedChoice in serializedNode.choices)
                {
                    node.CreateChoice(serializedChoice);
                }

                nodes.Add(node);
            }

            foreach (var serializedEdge in config.edges)
            {
                string outputId = serializedEdge.sourceNode;
                DialogueNode outputNode = nodes.First(it => it.Id == outputId);
                Port outputPort = outputNode.Choices[serializedEdge.index].Port;

                string inputId = serializedEdge.targetNode;
                DialogueNode inputNode = nodes.First(it => it.Id == inputId);
                Port inputPort = inputNode.InputPort;

                graphView.CreateEdge(inputPort, outputPort);
            }
        }

        public static void CreateDialog(DialogueGraph graph, out DialogueConfig config)
        {
            var path = EditorUtility.SaveFilePanelInProject("Save file", "Dialog", "asset", "");
            config = ScriptableObject.CreateInstance<DialogueConfig>();
            
            SaveDialog(graph, config);
            
            AssetDatabase.CreateAsset(config, path);
            AssetDatabase.SaveAssets();
        }

        public static void SaveDialog(DialogueGraph graph, DialogueConfig config)
        {
            config.nodes = ConvertNodesData(graph);
            config.edges = ConvertEdgesToData(graph);
            EditorUtility.SetDirty(config);
        }
        
        private static List<DialogueNodeSerialized> ConvertNodesData(GraphView graphView)
        {
            var result = new List<DialogueNodeSerialized>();
            
            foreach (var node in graphView.nodes)
            {
                var dialogueNode = (DialogueNode) node;
                var serializedNode = new DialogueNodeSerialized
                {
                    id = dialogueNode.Id,
                    message = dialogueNode.Message,
                    editorPosition = dialogueNode.GetPosition().center,
                    choices = ConvertChoicesToData(dialogueNode)
                };

                result.Add(serializedNode);
            }

            return result;
        }

        private static List<string> ConvertChoicesToData(DialogueNode nodeView)
        {
            var serializedChoices = new List<string>();
            foreach (var choice in nodeView.Choices)
            {
                var serializedChoice = choice.Choice;
                serializedChoices.Add(serializedChoice);
            }
            
            return serializedChoices;
        }

        private static List<DialogueEdgeSerialized> ConvertEdgesToData(GraphView graphView)
        {
            var serializedEdges = new List<DialogueEdgeSerialized>();
            
            foreach (var edge in graphView.edges)
            {
                Port outputPort = edge.output;
                Port inputPort = edge.input;
                
                var outputNode = (DialogueNode) outputPort.node;
                var inputNode = (DialogueNode) inputPort.node;

                var serializedEdge = new DialogueEdgeSerialized
                {
                    sourceNode = outputNode.Id,
                    targetNode = inputNode.Id,
                    index = outputNode.Choices.FindIndex(it => it.Port == outputPort)
                };

                serializedEdges.Add(serializedEdge);
            }

            return serializedEdges;
        }
    }
}
#endif