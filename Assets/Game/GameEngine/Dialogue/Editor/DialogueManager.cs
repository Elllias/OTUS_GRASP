#if UNITY_EDITOR

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Game.GameEngine.UnityEditor
{
    public static class DialogueManager
    {
        public static void LoadDialog(DialogueGraph graphView, DialogueConfig dialogue)
        {
            graphView.Reset();

            if (dialogue == null)
            {
                Debug.LogWarning("Dialog is null!");
                return;
            }

            var nodesCache = new List<DialogueNode>();
            foreach (var data in dialogue.nodes)
            {
                var node = DialogueNode.Instantiate(data.posiition);
                node.Id = data.id;
                node.Content = data.content;

                var choices = data.choices;
                for (var i = 0; i < choices.Length; i++)
                {
                    var choice = choices[i];
                    node.AddChoice(choice);
                }

                nodesCache.Add(node);
                graphView.AddElement(node);

                if (data.id == dialogue.entryId)
                {
                    node.SetAsEntry();
                }
            }

            foreach (var data in dialogue.edges)
            {
                var outputId = data.nodeId;
                var outputNode = nodesCache.First(it => it.Id == outputId);
                var outputPort = outputNode.Choices[data.choiceIndex].port;

                var inputId = data.nextId;
                var inputNode = nodesCache.First(it => it.Id == inputId);

                var edge = new Edge
                {
                    output = outputPort,
                    input = inputNode.InputPort
                };

                graphView.AddElement(edge);
            }

            graphView.generatedId = dialogue.generatedId;
        }

        public static void CreateDialog(DialogueGraph graphView, out DialogueConfig dialogue)
        {
            var path = EditorUtility.SaveFilePanelInProject("Save file", "Dialog", "asset", "");
            
            dialogue = ScriptableObject.CreateInstance<DialogueConfig>();
            SaveDialog(graphView, dialogue);
            
            AssetDatabase.CreateAsset(dialogue, path);
            AssetDatabase.SaveAssets();
        }

        public static void SaveDialog(DialogueGraph graphView, DialogueConfig dialogue)
        {
            dialogue.nodes = ConvertNodesData(graphView);
            dialogue.edges = ConvertEdgesToData(graphView);
            dialogue.entryId = graphView.GetEntryNode().Id;
            dialogue.generatedId = graphView.generatedId;
            EditorUtility.SetDirty(dialogue);
        }

        private static List<DialogueConfig.Node> ConvertNodesData(GraphView graphView)
        {
            var result = new List<DialogueConfig.Node>();
            var nodes = graphView.nodes;
            foreach (var view in nodes)
            {
                var nodeView = (DialogueNode) view;
                var data = new DialogueConfig.Node
                {
                    id = nodeView.Id,
                    content = nodeView.Content,
                    posiition = nodeView.GetPosition().center,
                    choices = ConvertChoicesToData(nodeView)
                };

                result.Add(data);
            }

            return result;
        }

        private static string[] ConvertChoicesToData(DialogueNode nodeView)
        {
            var choices = nodeView.Choices;
            var count = choices.Count;

            var result = new string[count];
            for (var i = 0; i < count; i++)
            {
                var choiceText = choices[i].textField.value;
                result[i] = choiceText;
            }

            return result;
        }

        private static List<DialogueConfig.Edge> ConvertEdgesToData(GraphView graphView)
        {
            var result = new List<DialogueConfig.Edge>();
            var edges = graphView.edges;
            foreach (var edge in edges)
            {
                var output = edge.output;
                var outputNode = (DialogueNode) output.node;
                var inputNode = (DialogueNode) edge.input.node;

                var data = new DialogueConfig.Edge
                {
                    nextId = inputNode.Id,
                    nodeId = outputNode.Id,
                    choiceIndex = outputNode.IndexOfChoice(output)
                };

                result.Add(data);
            }

            return result;
        }
    }
}
#endif