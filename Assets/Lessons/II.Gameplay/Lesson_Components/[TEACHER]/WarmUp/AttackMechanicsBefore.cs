// using Lessons.Architecture.Components;
// using UnityEngine;
//
// public sealed class AttackMechanics : MonoBehaviour
// {
//     [SerializeField] private EventReceiver attackReceiver;
//     [SerializeField] private TimerBehaviour countdown;
//     [SerializeField] private IntBehaviour damage;
//     [SerializeField] private Enemy enemy;
//
//     private void OnEnable() {
//         this.attackReceiver.OnEvent += this.OnRequiestAttack;
//     }
//
//     private void OnDisable() {
//         this.attackReceiver.OnEvent -= this.OnRequiestAttack;
//     }
//
//     private void OnRequiestAttack() {
//         if (this.countdown.IsPlaying) {
//             return;
//         }
//         
//         //Нанесение урона противнику: 
//         this.enemy.TakeDamage(this.damage.Value);
//             
//         //Запуск перезарядки:
//         this.countdown.ResetTime();
//         this.countdown.Play();
//     }
// }
//
//
