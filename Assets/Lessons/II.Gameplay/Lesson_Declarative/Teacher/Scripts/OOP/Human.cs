// using UnityEngine;
//
// namespace Lessons.Architecture.Lesson_Declarative
// {
//     public sealed class Human : MonoBehaviour
//     {
//         [SerializeField] private float speed;
//         [SerializeField] private GameObject bullet;
//         
//         public void Move(Vector3 direction) {
//             var offset = direction * this.speed;
//             var newPosition = this.transform.position + offset; 
//             this.transform.position = newPosition;
//             var rotation = Quaternion.LookRotation(direction, Vector3.up);
//             this.transform.rotation = rotation;
//         }
//     
//         public void Shoot(Vector3 direction) {
//             var position = this.transform.position;
//             var rotation = Quaternion.LookRotation(direction, Vector3.up);
//             Instantiate(this.bullet, position, rotation, null);
//         }
//     }
//     
//     
//     
//     public sealed class Human
//     {
//         public MoveComponent moveComponent = new();
//     
//         public ShootComponent shootComponent = new();
//     }
//     
//     
//     
//     
//     
//     
//     public sealed class MoveComponent : MonoBehaviour
//     {
//         [SerializeField]
//         private float speed;
//         
//         public void Move(Vector3 direction)
//         {
//             var offset = direction * this.speed;
//             var newPosition = this.transform.position + offset; 
//             this.transform.position = newPosition;
//     
//             var rotation = Quaternion.LookRotation(direction, Vector3.up);
//             this.transform.rotation = rotation;
//         }
//     }
//     
//     public sealed class ShootComponent : MonoBehaviour
//     {
//         [SerializeField]
//         private GameObject bullet;
//         
//         public void Shoot(Vector3 direction)
//         {
//             var position = this.transform.position;
//             var rotation = Quaternion.LookRotation(direction, Vector3.up);
//             Instantiate(this.bullet, position, rotation, null);
//         }
//     }
// }