// using Entities;
// using Lessons.AI.Lesson_TaskManager;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public interface IAttackComponent
//     {
//         void Attack(IEntity target);
//     }
//     
//     public class AttackComponent : MonoBehaviour, IAttackComponent
//     {
//         [SerializeField]
//         private CommandExecutor executor;
//         
//         public void Attack(IEntity target)
//         {
//             this.executor.ExecuteForce(new AttackCommand.Args(target));
//         }
//     }
// }