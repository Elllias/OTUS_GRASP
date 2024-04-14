// using System.Collections.Generic;
// using AI.Blackboards;
// using AI.Iterators;
// using Lessons.AI.Lesson_BehaviourTree1;
// using Lessons.AI.Lesson_Commands1;
// using UnityEngine;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_TaskManager
// {
//     public sealed class PatrolByPointsCommand : Command<PatrolByPointsCommand.Args>,
//         BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [Space]
//         [BlackboardKey]
//         [SerializeField]
//         private string patrolIteratorKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string moveToPositionKey;
//
//         [SerializeField]
//         private BehaviourNode node;
//
//         protected override void Execute(Args args)
//         {
//             var patrolIterator = args.CreateIterator();
//             this.blackboard.SetVariable(this.patrolIteratorKey, patrolIterator);
//             this.node.Run(callback: this);
//         }
//
//         protected override void OnInterrupt()
//         {
//             this.node.Abort();
//             this.blackboard.RemoveVariable(this.patrolIteratorKey);
//             this.blackboard.RemoveVariable(this.moveToPositionKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             this.blackboard.RemoveVariable(this.patrolIteratorKey);
//             this.Return(success);
//         }
//
//         public sealed class Args : ICommandArgs
//         {
//             public readonly IteratorMode patrolMode;
//
//             public readonly Vector3[] patrolPoints;
//
//             public Args(IteratorMode patrolMode, Vector3[] patrolPoints)
//             {
//                 this.patrolMode = patrolMode;
//                 this.patrolPoints = patrolPoints;
//             }
//
//             public IEnumerator<Vector3> CreateIterator()
//             {
//                 return IteratorFactory.CreateIterator(this.patrolMode, this.patrolPoints);
//             }
//         }
//     }
// }