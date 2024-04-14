// using System;
// using System.Collections.Generic;
// using UnityEngine;
//
// namespace Lessons.Architecture.GRASP
// {
//
//     public sealed class EnemySystem : MonoBehaviour
//     {
//         [Inject]
//         private ScenarioQuestManager questManager; //Жестко зависит от системы квестов...
//         private List<Enemy> currentEnemies;
//
//         public void OnEnable()
//         {
//             this.questManager.OnQuestCompleted += this.OnQuestFinished;
//         }
//
//         private void OnQuestFinished()
//         {
//             this.currentEnemies.ForEach(it => Destroy(it.gameObject));
//             this.currentEnemies.Clear();
//
//             var currentQuest = this.questManager.CurrentQuest;
//             var prefabs = currentQuest.GetEnemyPrefabs();
//             prefabs.ForEach(it => this.currentEnemies.Add(Instantiate(it)));
//         }
//     }
//     
//     
     
//      public sealed class EnemySystem : MonoBehaviour {
//          private List<Enemy> currentEnemies;
//
//          public void GenerateEnemies(Enemy[] prefabs) {
//              this.currentEnemies.ForEach(it => Destroy(it.gameObject));
//              this.currentEnemies.Clear();
//              prefabs.ForEach(it => this.currentEnemies.Add(Instantiate(it)));
//          }
//      }
//
//
//
// public sealed ScenarioQuestManager {
//     //Quest logic..
// }
//
//
// //     
//     public sealed class ScenarioEnemyController : MonoBehaviour {
//         
//         [Inject] private ScenarioQuestManager questManager;
//         [Inject] private ScenarioEnemyConfig scenarioConfig;
//         [Inject] private EnemySystem enemySystem;
//         
//         public void OnEnable() {
//             this.questManager.OnQuestCompleted += this.OnQuestFinished;
//         }
//
//         private void OnQuestFinished() {
//             var currentQuest = this.questManager.CurrentQuest;
//             var enemyPrefabs = scenarioConfig.GetEnemyPrefabs(currentQuest.Id);
//             this.enemySystem.GenerateEnemies(enemyPrefabs);
//         }
//     }
//     
//     
//     
// }