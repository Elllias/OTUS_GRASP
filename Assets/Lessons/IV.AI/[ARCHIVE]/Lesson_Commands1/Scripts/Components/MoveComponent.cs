// using Lessons.AI.Lesson_TaskManager;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public interface IMoveComponent
//     {
//         void MoveToPosition(Vector3 position);
//     }
//
//     public sealed class MoveComponent : MonoBehaviour, IMoveComponent
//     {
//         [SerializeField]
//         private CommandExecutor executor;
//
//         public void MoveToPosition(Vector3 position)
//         {
//             this.executor.ExecuteForce(new MoveToPositionCommand.Args(position));
//         }
//     }
// }