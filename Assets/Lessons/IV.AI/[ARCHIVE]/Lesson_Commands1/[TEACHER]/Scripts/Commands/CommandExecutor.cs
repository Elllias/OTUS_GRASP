// using System;
// using System.Collections.Generic;
// using Lessons.AI.Lesson_Commands1;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_TaskManager
// {
//     public sealed class CommandExecutor : MonoBehaviour, Command.ICallback
//     {
//         [ShowInInspector, ReadOnly]
//         public bool IsPlaying
//         {
//             get { return this.currentCommand != null; }
//         }
//
//         [ShowInInspector, ReadOnly]
//         private readonly Dictionary<Type, Command> commands = new();
//         
//         private Command currentCommand;
//
//         [Button]
//         public void ExecuteForce(ICommandArgs args)
//         {
//             this.Interrupt();
//             this.Execute(args);
//         }
//
//         [Button]
//         public void Execute(ICommandArgs args)
//         {
//             if (this.IsPlaying)
//             {
//                 Debug.LogWarning($"Other command {this.currentCommand.GetType().Name} is already run!");
//                 return;
//             }
//
//             if (!this.commands.TryGetValue(args.GetType(), out this.currentCommand))
//             {
//                 Debug.LogWarning($"Command with {args.GetType()} is not found!");
//                 return;
//             }
//
//             this.currentCommand.Execute(args, callback: this);
//         }
//
//         [Button]
//         public void Interrupt()
//         {
//             if (!this.IsPlaying)
//             {
//                 return;
//             }
//
//             this.currentCommand.Interrupt();
//             this.currentCommand = null;
//         }
//         
//         public void RegisterCommand<T>(Command command) where T : ICommandArgs
//         {
//             this.commands.Add(typeof(T), command);
//         }
//
//         public void UnregisterCommand<T>()
//         {
//             this.commands.Remove(typeof(T));
//         }
//
//         void Command.ICallback.Invoke(Command command, ICommandArgs args, bool success)
//         {
//             this.currentCommand = null;
//         }
//     }
// }