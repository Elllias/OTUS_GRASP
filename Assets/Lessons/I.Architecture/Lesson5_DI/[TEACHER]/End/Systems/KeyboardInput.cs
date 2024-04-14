// using System;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public sealed class KeyboardInput : IGameUpdateListener
//     {
//         public event Action<Vector2> OnMove;
//
//         void IGameUpdateListener.OnUpdate(float deltaTime)
//         {
//             this.HandleKeyboard();
//         }
//
//         private void HandleKeyboard()
//         {
//             if (Input.GetKey(KeyCode.UpArrow))
//             {
//                 this.Move(Vector2.up);
//             }
//             else if (Input.GetKey(KeyCode.DownArrow))
//             {
//                 this.Move(Vector2.down);
//             }
//             else if (Input.GetKey(KeyCode.LeftArrow))
//             {
//                 this.Move(Vector2.left);
//             }
//             else if (Input.GetKey(KeyCode.RightArrow))
//             {
//                 this.Move(Vector2.right);
//             }
//         }
//
//         private void Move(Vector2 direction)
//         {
//             this.OnMove?.Invoke(direction);
//         }
//     }
// }