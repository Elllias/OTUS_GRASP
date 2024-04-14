// using AI.Blackboards;
// using Entities;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
// using Blackboard = Lessons.AI.Architecture2.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public sealed class AttackTargetCommand : Command<AttackTargetCommand.Args>, BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string enemyKey;
//
//         [SerializeField]
//         private BehaviourNode attackNode;
//
//         protected override void Execute(Args args)
//         {
//             this.blackboard.AddVariable(this.enemyKey, args.enemy);
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
//             public readonly IEntity enemy;
//
//             public Args(IEntity enemy)
//             {
//                 this.enemy = enemy;
//             }
//         }
//     }
// }