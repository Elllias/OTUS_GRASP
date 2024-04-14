// using AI.Blackboards;
// using Lessons.AI.Lesson_BehaviourTree1;
// using Lessons.AI.Lesson_Commands1;
// using UnityEngine;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_TaskManager
// {
//     public sealed class MoveToPositionCommand : Command<MoveToPositionCommand.Args>,
//         BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [Space]
//         [BlackboardKey]
//         [SerializeField]
//         private string movePositionKey;
//
//         [SerializeField]
//         private BehaviourNode moveNode;
//
//         protected override void Execute(Args args)
//         {
//             this.blackboard.SetVariable(this.movePositionKey, args.targetPosition);
//             this.moveNode.Run(callback: this);
//         }
//
//         protected override void OnInterrupt()
//         {
//             this.moveNode.Abort();
//             this.blackboard.RemoveVariable(this.movePositionKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             this.blackboard.RemoveVariable(this.movePositionKey);
//             this.Return(success);
//         }
//
//         public sealed class Args : ICommandArgs
//         {
//             public readonly Vector3 targetPosition;
//
//             public Args(Vector3 targetPosition)
//             {
//                 this.targetPosition = targetPosition;
//             }
//         }
//     }
// }