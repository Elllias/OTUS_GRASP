// using System;
// using System.Collections.Generic;
// using AI.BTree;
// using AI.GOAP;
// using UnityEngine;
//
// namespace Game.GameEngine
// {
//     [Serializable]
//     public sealed class GoalOrientedConverter : MonoBehaviour
//     {
//         [SerializeField]
//         private NodeInfo[] nodes = new NodeInfo[0];
//
//         public IBehaviourNode ConvertToBTSequence(IAct[] actionList)
//         {
//             var result = new List<IBehaviourNode>();
//             for (int i = 0, count = actionList.Length; i < count; i++)
//             {
//                 var action = actionList[i];
//                 var nodeSequence = this.FindBTNode(action.Id); 
//                 result.AddRange(nodeSequence);
//             }
//
//             return new BehaviourNodeSequence(result.ToArray());
//         }
//
//         private UnityBehaviourNode[] FindBTNode(string actionName)
//         {
//             for (int i = 0, count = this.nodes.Length; i < count; i++)
//             {
//                 var nodeInfo = this.nodes[i];
//                 if (nodeInfo.planAction.Name == actionName)
//                 {
//                     return nodeInfo.sequence;
//                 }
//             }
//
//             throw new Exception($"Action {actionName} is not found!");
//         }
//
//         [Serializable]
//         private sealed class NodeInfo
//         {
//             [Space(12)]
//             [SerializeField]
//             public MonoAct planAction;
//
//             [SerializeField]
//             public UnityBehaviourNode[] sequence;
//         }
//     }
// }