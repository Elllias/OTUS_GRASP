// using AI.Blackboards;
// using Entities;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public sealed class AttackCommand : Command<AttackCommand.Args>, BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private BehaviourNode attackNode;
//
//         [Space]
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string enemyKey;
//
//         protected override void Execute(Args args)
//         {
//             this.blackboard.SetVariable(this.enemyKey, args.target);
//             this.attackNode.Run(callback: this);
//         }
//
//         protected override void OnInterrupt()
//         {
//             this.attackNode.Abort();
//             this.blackboard.RemoveVariable(this.enemyKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             this.blackboard.RemoveVariable(this.enemyKey);
//             this.Return(success);
//         }
//
//         public sealed class Args : ICommandArgs
//         {
//             public readonly IEntity target;
//
//             public Args(IEntity target)
//             {
//                 this.target = target;
//             }
//         }
//     }
// }