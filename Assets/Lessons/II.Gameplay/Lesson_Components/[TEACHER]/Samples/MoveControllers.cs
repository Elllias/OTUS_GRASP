// using UnityEngine;
//
// namespace Teacher.Architecture.Components
// {
//     public sealed class CharacterMoveController : MonoBehaviour
//     {
//         [SerializeField]
//         private Character character;
//
//         private void Update()
//         {
//             this.HandleKeyboard();
//         }
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
//
//         private void Move(Vector3 direction)
//         {
//             const float speed = 5.0f;
//             this.character.Move(direction * (speed * Time.deltaTime));
//         }
//     }
// }


// public sealed class MoveController : MonoBehaviour
// {
//     [SerializeField]
//     private Entity unit;
//
//     private void Update()
//     {
//         this.HandleKeyboard();
//     }
//
//     private void HandleKeyboard()
//     {
//         if (Input.GetKey(KeyCode.UpArrow))
//         {
//             this.Move(Vector3.forward);
//         }
//         else if (Input.GetKey(KeyCode.DownArrow))
//         {
//             this.Move(Vector3.back);
//         }
//         else if (Input.GetKey(KeyCode.LeftArrow))
//         {
//             this.Move(Vector3.left);
//         }
//         else if (Input.GetKey(KeyCode.RightArrow))
//         {
//             this.Move(Vector3.right);
//         }
//     }
//
//     private void Move(Vector3 direction)
//     {
//         const float speed = 5.0f;
//         this.unit.Get<IMoveComponent>().Move(direction * (speed * Time.deltaTime));
//     }
// }

// using UnityEngine;
//
// namespace Teacher.Architecture.Components
// {
//     public sealed class EnemyMoveController : MonoBehaviour
//     {
//         [SerializeField]
//         private Enemy enemy;
//
//         private void Update()
//         {
//             this.HandleKeyboard();
//         }
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
//
//         private void Move(Vector3 direction)
//         {
//             const float speed = 5.0f;
//             this.enemy.Move(direction * (speed * Time.deltaTime));
//         }
//     }
// }