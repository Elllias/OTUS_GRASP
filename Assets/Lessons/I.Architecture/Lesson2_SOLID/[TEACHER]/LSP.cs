// // using System;
// // using UnityEngine;
// //
// // //Неправильное использование LSP 
//
//
// using UnityEngine;
//
// public class Player : MonoBehaviour
// {
//     public int hitPoints;
//     public int damage;
//     public int moveSpeed;
//
//     public virtual void Move(Vector3 direction)
//     {
//         this.transform.position += direction * this.moveSpeed;
//         this.transform.rotation = Quaternion.LookRotation(direction);
//     }
//
//     public virtual void Attack(Player target)
//     {
//         target.hitPoints -= damage;
//     }
// }
//
// public class Catapulta : Player
// {
//     public override void Move(Vector3 vector)
//     {
//         throw new Exception("Can't move!");
//     }
// }
//
//
//         public abstract class AbstractWeapon
//         {
//             public int Bullets { get; private set; }
//             public float Countdown { get; private set; }
//
//             public bool CanFire() => 
//                 this.Bullets > 0 && this.Countdown < 0;
//
//             public void Fire() 
//             {
//                 if (this.CanFire()) {
//                     this.ProcessFire();
//                     this.Bullets--;
//                     this.Countdown = 5.0f;
//                 }
//             }
//
//             protected abstract void ProcessFire();
//         }
//
//         public sealed class MeleeWeapon : AbstractWeapon {}
//
//         public sealed class BulletWeapon : AbstractWeapon {}
//
//         public sealed class RayWeapon : AbstractWeapon {}
//
//
//
//
// public interface IMessenger
// {
//     void SendText(string text);
//     void SendVoice(byte[] voice);
// }
//
// public sealed class TelegrammMessenger : IMessenger
// {
//     public void SendText(string text)
//     {
//     }
//
//     public void SendVoice(byte[] voice)
//     {
//     }
// }
//
// public sealed class 
//
//
// //
// // using System;
// // using UnityEngine;
// //
// //     [Serializable]
// //     public sealed class HitPointsComponent
// //     {
// //         [field: SerializeField]
// //         public int HitPoints { get; set; }
// //     }
// //
// //     [Serializable]
// //     public sealed class AttackComponent
// //     {
// //         [SerializeField]
// //         private int damage;
// //
// //         public void Attack(HitPointsComponent target) {
// //             target.HitPoints -= this.damage;
// //         }
// //     }
// //
// //     [Serializable]
// //     public sealed class MoveComponent
// //     {
// //         [SerializeField] private Transform transform;
// //         [SerializeField] private float moveSpeed;
// //         
// //         public void Move(Vector3 direction) {
// //             this.transform.position += direction * this.moveSpeed;
// //             this.transform.rotation = Quaternion.LookRotation(direction);
// //         }
// //     }
// //
// //     public class Player : MonoBehaviour
// //     {
// //         [field: SerializeField]
// //         public HitPointsComponent HitPointsComponent { get; private set; }
// //
// //         [field: SerializeField]
// //         public MoveComponent MoveComponent { get; private set; }
// //         
// //         [field: SerializeField]
// //         public AttackComponent AttackComponent { get; private set; }
// //     }
// //
// //     public class Catapulta : MonoBehaviour
// //     {
// //         [field: SerializeField]
// //         public HitPointsComponent HitPointsComponent { get; private set; }
// //
// //         [field: SerializeField]
// //         public AttackComponent AttackComponent { get; private set; }
// //     }
//
//
// //
// // public class Worker : Unit {
// //     
// //     public override void Attack(Unit target)
// //     {
// //         throw new Exception("Can't attack!");
// //     }
// // }
// //
// // //Правильное использование:
// // public class HitPointsComponent : MonoBehaviour {
// //     public int hitPoints;
// // }
// //
// // public class AttackComponent : MonoBehaviour {
// //     
// //     public int damage;
// //
// //     public void Attack(GameObject target) {
// //         if (target.TryGetComponent(out HitPointsComponent component)) {
// //             component.hitPoints -= this.damage;
// //         }
// //     }
// // }
// //
// // public class MoveComponent : MonoBehaviour {
// //     
// //     public void Move(Vector3 vector) {
// //         this.transform.position += vector;
// //         this.transform.rotation = Quaternion.LookRotation(vector);
// //     }
// // }