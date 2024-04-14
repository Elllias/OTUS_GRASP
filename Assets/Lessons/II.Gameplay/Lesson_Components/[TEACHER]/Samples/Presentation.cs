// using System;
// using Lessons.Architecture.Components;
// using Repetition.Architecture.Components;
// using UnityEngine;
//
// namespace Teacher.Architecture.Components
// {
//     // public sealed class MoveController : MonoBehaviour
//     // {
//     //     [SerializeField]
//     //     private MonoBehaviour unit;
//     //
//     //     private void Update()
//     //     {
//     //         this.HandleKeyboard();
//     //     }
//     //
//     //     private void Move(Vector3 direction)
//     //     {
//     //         const float speed = 5.0f;
//     //         if (this.unit is Character character)
//     //         {
//     //             character.Move(direction * (speed * Time.deltaTime));
//     //         }
//     //         else if (this.unit is Enemy enemy)
//     //         {
//     //             enemy.Move(direction * (speed * Time.deltaTime));
//     //         }
//     //     }
//     //
//     //
//     //     private void HandleKeyboard()
//     //     {
//     //         if (Input.GetKey(KeyCode.UpArrow))
//     //         {
//     //             this.Move(Vector3.forward);
//     //         }
//     //         else if (Input.GetKey(KeyCode.DownArrow))
//     //         {
//     //             this.Move(Vector3.back);
//     //         }
//     //         else if (Input.GetKey(KeyCode.LeftArrow))
//     //         {
//     //             this.Move(Vector3.left);
//     //         }
//     //         else if (Input.GetKey(KeyCode.RightArrow))
//     //         {
//     //             this.Move(Vector3.right);
//     //         }
//     //     }
//     // }
//
//     public sealed class MoveController : MonoBehaviour
//     {
//         [SerializeField]
//         private Unit unit;
//
//         private void Update()
//         {
//             this.HandleKeyboard();
//         }
//
//         private void Move(Vector3 direction)
//         {
//             const float speed = 5.0f;
//             this.unit.Move(direction * (speed * Time.deltaTime));
//         }
//
//
//         private void HandleKeyboard()
//         {
//             if (Input.GetKey(KeyCode.UpArrow))
//             {
//                 this.Move(Vector3.forward);
//             }
//             else if (Input.GetKey(KeyCode.DownArrow))
//             {
//                 this.Move(Vector3.back);
//             }
//             else if (Input.GetKey(KeyCode.LeftArrow))
//             {
//                 this.Move(Vector3.left);
//             }
//             else if (Input.GetKey(KeyCode.RightArrow))
//             {
//                 this.Move(Vector3.right);
//             }
//         }
//     }
//
//     public abstract class Unit : MonoBehaviour
//     {
//         [SerializeField]
//         private EventReceiver attackReceiver;
//
//         [SerializeField]
//         private IntEventReceiver takeDamageReceiver;
//
//         [SerializeField]
//         private Vector3EventReceiver moveReceiver;
//
//         public virtual void Attack()
//         {
//             this.attackReceiver.Call();
//         }
//
//         public virtual void TakeDamage(int damage)
//         {
//             this.takeDamageReceiver.Call(damage);
//         }
//
//         public virtual void Move(Vector3 vector)
//         {
//             this.moveReceiver.Call(vector);
//         }
//     }
//
//     public sealed class Character : Unit
//     {
//     }
//
//     public sealed class Enemy : Unit
//     {
//         public override void Attack() {
//             throw new NotImplementedException();
//         }
//     }
// }