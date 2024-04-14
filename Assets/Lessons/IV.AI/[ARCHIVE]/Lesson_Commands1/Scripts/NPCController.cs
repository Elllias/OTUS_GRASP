// using System.Linq;
// using AI.Iterators;
// using Entities;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public sealed class NPCController : MonoBehaviour
//     {
//         [SerializeField]
//         private MonoEntity unit;
//
//         [Button]
//         public void MoveToPosition(Transform point)
//         {
//             this.unit.Get<IMoveComponent>().MoveToPosition(point.position);
//         }
//
//         [Button]
//         public void AttackTarget(IEntity target)
//         {
//             this.unit.Get<IAttackComponent>().Attack(target);
//         }
//
//         [Button]
//         public void Patrol(IteratorMode patrolMode, Transform[] waypoints)
//         {
//             this.unit.Get<IPatrolComponent>().Patrol(patrolMode, waypoints.Select(it => it.position));
//         }
//
//         [Button]
//         public void Stop()
//         {
//             this.unit.Get<IStopComponent>().Stop();
//         }
//     }
// }