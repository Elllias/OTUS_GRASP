// using System;
// using MyLittleUniverse.Tutorial;
// using UnityEngine;
// using UnityEngine.UI;
// #pragma warning disable CS0649
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     
//     
//     public sealed class ShopButton : MonoBehaviour {
//         
//         private TutorialManager tutorialManager;
//
//         [SerializeField]
//         private Button button;
//
//         private void OnEnable() {
//             this.button.onClick.AddListener(this.OnShopButtonClicked);
//             this.button.interactable = this.tutorialManager.IsCompleted;
//             this.tutorialManager.OnCompleted += this.OnTutorialCompleted;
//         }
//         
//         private void OnDisable() {
//             this.button.onClick.RemoveListener(this.OnShopButtonClicked);
//             this.tutorialManager.OnCompleted -= this.OnTutorialCompleted;
//         }
//
//         private void OnTutorialCompleted() {
//             this.button.interactable = true;
//         }
//
//         private void OnShopButtonClicked() {
//             //TODO: Show Shop Popup...
//         }
//     }
//     
//     
//     
//     
// }