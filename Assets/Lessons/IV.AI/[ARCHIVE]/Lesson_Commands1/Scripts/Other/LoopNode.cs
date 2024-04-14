// using System;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_TaskManager
// {
//     public sealed class LoopNode : BehaviourNode
//     {
//         [SerializeField]
//         private BehaviourNode childNode;
//
//         private void Awake()
//         {
//             this.enabled = false;
//         }
//
//         protected override void Run()
//         {
//             this.childNode.Run(null);
//             this.enabled = true;
//         }
//
//         protected override void OnAbort()
//         {
//             this.childNode.Abort();
//             this.enabled = false;
//         }
//
//         private void FixedUpdate()
//         {
//             if (!this.childNode.IsRunning)
//             {
//                 this.childNode.Run(null);                
//             }
//         }
//     }
// }