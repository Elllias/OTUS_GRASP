// using Teacher.Architecture.Components;
// using UnityEngine;
//
// public sealed class AttackMechanics : MonoBehaviour
// {
//     [SerializeField] private EntityEventReceiver attackReceiver;
//     [SerializeField] private TimerBehaviour countdown;
//     [SerializeField] private IntBehaviour damage;
//
//     private void OnEnable() {
//         this.attackReceiver.OnEvent += this.OnRequiestAttack;
//     }
//
//     private void OnDisable() {
//         this.attackReceiver.OnEvent -= this.OnRequiestAttack;
//     }
//
//     private void OnRequiestAttack(Entity target) {
//         if (this.countdown.IsPlaying) {
//             return;
//         }
//         
//         //Нанесение урона противнику: 
//         target.Get<ITakeDamageComponent>().TakeDamage(this.damage.Value);
//             
//         //Запуск перезарядки:
//         this.countdown.ResetTime();
//         this.countdown.Play();
//     }
// }