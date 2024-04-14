// using System.Collections.Generic;
// using System.Linq;
// using AI.Iterators;
// using Lessons.AI.Lesson_TaskManager;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public interface IPatrolComponent
//     {
//         void Patrol(IteratorMode patrolMode, IEnumerable<Vector3> points);
//     }
//
//     public sealed class PatrolComponent : MonoBehaviour, IPatrolComponent
//     {
//         [SerializeField]
//         private CommandExecutor executor;
//
//         public void Patrol(IteratorMode patrolMode, IEnumerable<Vector3> points)
//         {
//             this.executor.ExecuteForce(new PatrolByPointsCommand.Args(patrolMode, points.ToArray()));
//         }
//     }
// }