// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.AI.Lesson_Commands1
// {
//     public abstract class Command : MonoBehaviour
//     {
//         [ShowInInspector, ReadOnly]
//         public bool IsPlaying { get; private set; }
//
//         private ICallback callback;
//
//         private ICommandArgs args;
//
//         [Button]
//         public void Execute(ICommandArgs args, ICallback callback)
//         {
//             if (this.IsPlaying)
//             {
//                 return;
//             }
//
//             this.callback = callback;
//             this.args = args;
//             this.IsPlaying = true;
//             this.Execute(args);
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
//             this.IsPlaying = false;
//             this.OnInterrupt();
//         }
//
//         protected abstract void Execute(ICommandArgs args);
//
//         protected virtual void OnInterrupt()
//         {
//         }
//
//         public void Return(bool success)
//         {
//             if (!this.IsPlaying)
//             {
//                 return;
//             }
//
//             this.IsPlaying = false;
//             if (this.callback == null)
//             {
//                 return;
//             }
//
//             var callback = this.callback;
//             this.callback = null;
//             callback.Invoke(this, this.args, success);
//         }
//
//         public interface ICallback
//         {
//             void Invoke(Command command, ICommandArgs args, bool success);
//         }
//     }
//
//     public abstract class Command<T> : Command where T : ICommandArgs
//     {
//         protected sealed override void Execute(ICommandArgs args)
//         {
//             if (args is not T tArgs)
//             {
//                 Debug.LogWarning("Mismatch command type");
//                 this.Return(false);
//                 return;
//             }
//
//             this.Execute(tArgs);
//         }
//
//         protected abstract void Execute(T args);
//     }
// }