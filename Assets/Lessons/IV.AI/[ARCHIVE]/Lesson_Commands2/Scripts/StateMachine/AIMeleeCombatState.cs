// using AI.Blackboards;
// using Elementary;
// using Game.GameEngine.Mechanics;
// using Lessons.AI.Lesson_BehaviourTree1;
// using UnityEngine;
// using UnityEngine.Serialization;
// using Blackboard = Lessons.AI.HierarchicalStateMachine.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands2
// {
//     public sealed class AIMeleeCombatState : MonoState, BehaviourNode.ICallback
//     {
//         [SerializeField]
//         private UCombatOperator meleeCombatOperator;
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
//         private string targetKey;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//
//         [FormerlySerializedAs("moveNode")]
//         [Space]
//         [SerializeField]
//         private BehaviourNode attackNode;
//
//         public override void Enter()
//         {
//             this.blackboard.SetVariable(this.targetKey, this.meleeCombatOperator.Current.targetEntity);
//             this.blackboard.SetVariable(this.stoppingDistanceKey, this.stoppingDistance.Current);
//             this.attackNode.Run(callback: this);
//         }
//
//         public override void Exit()
//         {
//             this.attackNode.Abort();
//             this.blackboard.RemoveVariable(this.targetKey);
//             this.blackboard.RemoveVariable(this.stoppingDistanceKey);
//         }
//
//         void BehaviourNode.ICallback.Invoke(BehaviourNode node, bool success)
//         {
//             //TODO: TARGET DESTROYED BLACKBOARD KEY...
//             this.meleeCombatOperator.Stop();
//         }
//     }
// }