// using System.Collections.Generic;
// using System.Linq;
// using AI.Blackboards;
// using AI.Iterators;
// using Elementary;
// using Game.GameEngine.Mechanics;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands2
// {
//     public sealed class AIPatrolByPointsState : MonoState, BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private UPatrolByPointsEngine patrolEngine;
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
//         private string waypointsKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//         
//         [BlackboardKey]
//         [SerializeField]
//         private string moveToPositionKey;
//
//         [Space]
//         [SerializeField]
//         private BehaviourNode patrolNode;
//
//         public override void Enter()
//         {
//             this.blackboard.SetVariable(this.stoppingDistanceKey, this.stoppingDistance.Current);
//             this.blackboard.SetVariable(this.waypointsKey, this.CreateIterator());
//             this.patrolNode.Run(callback: this);
//         }
//
//         public override void Exit()
//         {
//             this.patrolNode.Abort();
//             this.blackboard.RemoveVariable(this.stoppingDistanceKey);
//             this.blackboard.RemoveVariable(this.moveToPositionKey);
//             this.blackboard.RemoveVariable(this.waypointsKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             this.patrolEngine.StopPatrol();
//         }
//
//         private IEnumerator<Vector3> CreateIterator()
//         {
//             var points = this.patrolEngine.CurrentOperation.points.ToArray();
//             return IteratorFactory.CreateIterator(IteratorMode.YOYO, points);
//         }
//     }
// }