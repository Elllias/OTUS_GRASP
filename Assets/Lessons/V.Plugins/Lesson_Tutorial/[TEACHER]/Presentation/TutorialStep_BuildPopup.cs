// // // using UnityEngine;
// // // using UnityEngine.UI;
// // // // ReSharper disable UnusedMember.Global
// // //
// //
// // using Game.Tutorial.Gameplay;
// // using GameSystem;
// // using UnityEngine;
// // using UnityEngine.UI;
// //
// // namespace Lessons.PRESENTATION.TUTORIAL
// // {
// //     // public sealed class TutorialStep_BuildPopup : TutorialStepController
// //     // {
// //     //     protected override void OnStart()
// //     //     {
// //     //         //Найти попап на сцене:
// //     //         var buildPopup = FindObjectOfType<BuildPopup>();
// //     //
// //     //         //Найти кнопку "Закрыть" и выкл ее:
// //     //         foreach (Transform child in buildPopup.transform)
// //     //         {
// //     //             if (child.name == "ButtonClose")
// //     //             {
// //     //                 child.GetComponent<Button>().interactable = false;
// //     //             }
// //     //         }
// //     //     }
// //     // }
// //     //
// //     //
// //     
// //
// //     public sealed class TutorialStep_BuildPopup : TutorialStepController
// //     {
// //         [GameInject]
// //         private TutorialProvider_BuildPopup popupProvider;
// //     
// //         protected override void OnStart()
// //         {
// //             this.popupProvider.closeButton.interactable = false;
// //         }
// //     }
//
//        
//      public sealed class TutorialStep_BuildPopup : TutorialStepController
//      {
//          [SerializeField] //Ссылка через Unity
//          public Button closeButton;
//      
//          protected override void OnStart()
//          {
//              this.closeButton.interactable = false;
//          }
//      }
//
//
// //
// //     public sealed class TutorialProvider_BuildPopup : MonoBehaviour
// //     {
// //         [SerializeField]
// //         public Button closeButton;
// //
// //         [SerializeField]
// //         public Transform contentTransform;
// //     }
// //
// //     
// //     
// //
// // //
// //
// //
// // //     
// // //     
// // //     
// //     public sealed class BuildPopup : MonoBehaviour
// //     {
// //     }
// // }