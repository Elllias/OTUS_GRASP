// using Lessons.AI.Lesson_Commands1;
// using Lessons.AI.Lesson_TaskManager;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands
// {
//     public sealed class CommandExecutorInstaller : MonoBehaviour
//     {
//         [SerializeField]
//         private CommandExecutor commandExecutor;
//
//         [Space]
//         [SerializeField]
//         private Command moveCommand;
//
//         [SerializeField]
//         private Command attackCommand;
//         
//         [SerializeField]
//         private Command patrolCommand;
//
//         private void Awake()
//         {
//             this.commandExecutor.RegisterCommand<MoveToPositionCommand.Args>(this.moveCommand);
//             this.commandExecutor.RegisterCommand<AttackTargetCommand.Args>(this.attackCommand);
//             this.commandExecutor.RegisterCommand<PatrolByPointsCommand.Args>(this.patrolCommand);
//         }
//     }
// }