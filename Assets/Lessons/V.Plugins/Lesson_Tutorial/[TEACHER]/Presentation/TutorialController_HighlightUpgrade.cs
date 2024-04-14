// using System;
// using Lessons.LESSON.HEROUPGRADES2;
// using MyLittleUniverse.UI;
// using UnityEngine;
// // ReSharper disable UnusedMember.Global
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     
//     
//     
//     public sealed class TutorialController_HighlightUpgrade : MonoBehaviour {
//         
//         [SerializeField] private UpgradesPopup upgradesPopup;
//         [SerializeField] private UpgradeView[] upgradeViews;
//
//         [SerializeField] private GameObject fingerPrefab;
//         [SerializeField] private Color highlightColor;
//         [SerializeField] private GameObject foregroundPrefab;
//         
//         public void StartStep() {
//             //Создать затемнение в попапе:
//             Instantiate(this.foregroundPrefab, upgradesPopup.RootTransform);
//             
//             //Подсветить первый апгрейд:
//             var firstUpgrade = this.upgradeViews[0];
//             firstUpgrade.SetBackgroundColor(this.highlightColor);
//             firstUpgrade.transform.SetParent(upgradesPopup.RootTransform);
//             
//             //Заспаунить палец:
//             Instantiate(this.fingerPrefab, firstUpgrade.FingerTransform);
//         }
//     }
//     
//     
//     public sealed class UpgradesPopup : MonoBehaviour
//     {
//         public Transform RootTransform { get; set; }
//     }
//
//
//
//
//     public sealed class UpgradeView : MonoBehaviour
//     {
//         public event Action OnClicked;
//             
//         public void SetBackgroundColor(Color color)
//         {
//             throw new System.NotImplementedException();
//         }
//
//         public Transform FingerTransform { get; set; }
//
//         public void SetInactive()
//         {
//                 
//         }
//     }
//         
//     public sealed class UpgradesPresenter : MonoBehaviour
//     {
//             
//     }
// }