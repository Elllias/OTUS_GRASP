// using AI.Blackboards;
// using Elementary;
// using Game.GameEngine.Mechanics;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands2
// {
//     public sealed class AIMoveToPositionState : MonoState, BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private UMoveToPositionMotor moveEngine;
//
//         [SerializeField]
//         private FloatAdapter stoppingDistance;
//
//         [Space]
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string positionKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//
//         [Space]
//         [SerializeField]
//         private BehaviourNode moveNode;
//
//         public override void Enter()
//         {
//             this.blackboard.SetVariable(this.positionKey, this.moveEngine.TargetPosition);
//             this.blackboard.SetVariable(this.stoppingDistanceKey, this.stoppingDistance.Current);
//             this.moveNode.Run(callback: this);
//         }
//
//         public override void Exit()
//         {
//             this.moveNode.Abort();
//             this.blackboard.RemoveVariable(this.positionKey);
//             this.blackboard.RemoveVariable(this.stoppingDistanceKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             Debug.Log($"MOVE FINISHED {success}");
//             this.moveEngine.StopMove();
//         }
//     }
// }