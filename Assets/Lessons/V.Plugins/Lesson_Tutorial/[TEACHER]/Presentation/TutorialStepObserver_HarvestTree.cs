// using GameElements;
// using Sirenix.Utilities;
// // ReSharper disable UnusedType.Global
// // ReSharper disable UnusedMember.Global
//
// namespace Lessons.PRESENTATION.TUTORIAL
// {
//     
//     
//     

// using Game.Tutorial.Gameplay;
// using GameSystem;
// using Sirenix.Utilities;
// using UnityEngine;
//
// namespace Presentation
// {
//     public sealed class TutorialProvider_HarvestTrees : MonoBehaviour
//     {
//         public GameObject targetTree;
//
//         public GameObject[] otherTress;
//     }
//
//     public class TutorialStepObserver_HarvestTree : TutorialStepController
//     {
//         [GameInject]
//         private TutorialProvider_HarvestTrees treesProvider;
//
//         protected override void OnStart()
//         {
//             this.treesProvider.targetTree.SetActive(true);
//             this.treesProvider.otherTress.ForEach(it => it.SetActive(false));
//         }
//
//         protected override void OnStop()
//         {
//             this.treesProvider.otherTress.ForEach(it => it.SetActive(true));
//         }
//     }
// }

//     
//     
//     
//     
// }


// using System;
// using Game.Gameplay.Player;
// using Game.Tutorial.Gameplay;
// using Game.Tutorial.UI;
// using GameSystem;
// using UnityEngine;
//
// namespace Game.Tutorial
// {
//     public sealed class MoveToUpgradeStep
//     {
//         private PointerManager pointerManager;
//         private NavigationManager navigationManager;
//         private ScreenTransform screenTransform;
//         private WorldPlacePopupShower worldPlacePopupShower;
//         private readonly MoveToUpgradeInspector actionInspector = new();
//         [SerializeField] private UpgradeHeroConfig config;
//         [SerializeField] private MoveToUpgradePanelShower actionPanel;
//         [SerializeField] private Transform pointerTransform;
//         [SerializeField] private UpgradePopupShower popupShower;
//         private Action onComplete;
//
//         public void Run(Action onComplete) {
//             this.onComplete = onComplete;
//             
//             //Подписываемся на подход к месту:
//             this.actionInspector.Inspect(this.OnPlaceVisited);
//
//             //Показываем указатель:
//             var targetPosition = this.pointerTransform.position;
//             this.pointerManager.ShowPointer(targetPosition, this.pointerTransform.rotation);
//             this.navigationManager.StartLookAt(targetPosition);
//
//             //Показываем квест в UI:
//             this.actionPanel.Show(this.screenTransform.Value);
//         }
//         
//         private void OnPlaceVisited() {
//             //Убираем указатель
//             this.pointerManager.HidePointer();
//             this.navigationManager.Stop();
//
//             //Убираем квест из UI:
//             this.actionPanel.Hide();
//
//             //Показываем попап:
//             this.popupShower.ShowPopup();
//             
//             //Возвращаем базовый триггер:
//             this.worldPlacePopupShower.SetEnable(true);
//             this.onComplete?.Invoke();
//         }
//     }
// }