// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Lessons.MetaGame.Dialogs
// {
//     [CreateAssetMenu(
//         fileName = "DialogueConfig",
//         menuName = "Lessons/New DialogueConfig"
//     )]
//     public sealed class DialogueConfig : ScriptableObject
//     {
//         public string startNodeId;
//         public List<DialogueNodeSerialized> nodes;
//         public List<DialogueEdgeSerialized> edges;
//         
//         public bool FindStartNode(out DialogueNodeSerialized node)
//         {
//             return this.FindNode(this.startNodeId, out node);
//         }
//
//         private bool FindNode(string id, out DialogueNodeSerialized result)
//         {
//             foreach (var node in this.nodes)
//             {
//                 if (node.id == id)
//                 {
//                     result = node;
//                     return true;
//                 }
//             }
//         
//             result = default;
//             return false;
//         }
//
//         public bool FindNextNode(string sourceNodeId, int choiceIndex, out DialogueNodeSerialized nextNode)
//         {
//             for (int i = 0, count = this.edges.Count; i < count; i++)
//             {
//                 var edge = this.edges[i];
//                 if (edge.sourceNodeId == sourceNodeId && edge.index == choiceIndex)
//                 {
//                     if (this.FindNode(edge.targetNodeId, out nextNode))
//                     {
//                         return true;
//                     }
//         
//                     return false;
//                 }
//             }
//
//             nextNode = default;
//             return false;
//         }
//     }
// }