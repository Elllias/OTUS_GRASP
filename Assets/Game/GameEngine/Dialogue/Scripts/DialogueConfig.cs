using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.GameEngine
{
    [CreateAssetMenu(
        fileName = "DialogueConfig",
        menuName = "Dialogs/New DialogueConfig"
    )]
    public sealed class DialogueConfig : ScriptableObject
    {
        [Header("Meta")]
        [SerializeField]
        public Sprite icon;

        [Header("Editor")]
        [SerializeField]
        public List<Node> nodes;

        [SerializeField]
        public List<Edge> edges;

        [SerializeField]
        public int entryId;

        [SerializeField]
        public int generatedId;

        public bool FindEntryNode(out Node node)
        {
            return this.FindNode(this.entryId, out node);
        }

        public bool FindNextNode(int prevId, int choiceIndex, out Node nextNode)
        {
            for (int i = 0, count = this.edges.Count; i < count; i++)
            {
                var edge = this.edges[i];
                if (edge.nodeId == prevId && edge.choiceIndex == choiceIndex)
                {
                    if (this.FindNode(edge.nextId, out nextNode))
                    {
                        return true;
                    }
        
                    return false;
                }
            }

            nextNode = default;
            return false;
        }

        private bool FindNode(int id, out Node result)
        {
            foreach (var node in this.nodes)
            {
                if (node.id == id)
                {
                    result = node;
                    return true;
                }
            }
        
            result = default;
            return false;
        }

        [Serializable]
        public struct Node
        {
            [SerializeField]
            public int id;

            [SerializeField]
            public string content;

            [SerializeField]
            public string[] choices;

            [SerializeField]
            public Vector2 posiition;
        }

        [Serializable]
        public struct Edge
        {
            [SerializeField, FormerlySerializedAs("outputId")]
            public int nodeId;

            [SerializeField, FormerlySerializedAs("outputIndex")]
            public int choiceIndex;

            [SerializeField, FormerlySerializedAs("inputId")]
            public int nextId;
        }
    }
}