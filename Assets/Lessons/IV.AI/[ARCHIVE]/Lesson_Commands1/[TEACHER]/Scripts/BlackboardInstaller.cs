// using AI.Blackboards;
// using Entities;
// using UnityEngine;
// using Blackboard = Lessons.AI.Architecture2.Blackboard;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public sealed class BlackboardInstaller : MonoBehaviour
//     {
//         [SerializeField]
//         private Blackboard blackboard;
//
//         [BlackboardKey]
//         [SerializeField]
//         private string unitKey;
//
//         [SerializeField]
//         private UnityEntity unit;
//
//
//         [BlackboardKey]
//         [SerializeField]
//         private string stoppingDistanceKey;
//
//         [SerializeField]
//         private float stoppingDistance = 0.5f;
//
//         private void Awake()
//         {
//             this.blackboard.AddVariable(this.unitKey, this.unit);
//             this.blackboard.AddVariable(this.stoppingDistanceKey, this.stoppingDistance);
//         }
//     }
// }