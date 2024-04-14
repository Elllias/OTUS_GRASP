// // // using System;
// // // using System.Collections;
// // // using Game.Meta;
// // // using InputModule;
// // // using UnityEngine;
// // //
// // // #pragma warning disable CS0067
// // //
// // // // ReSharper disable Unity.RedundantEventFunction
// // // // ReSharper disable ArrangeTypeMemberModifiers
// // //
// // // // ReSharper disable UnusedType.Global
// // // // ReSharper disable EventNeverSubscribedTo.Global
// // // // ReSharper disable UnusedMember.Global
// // //
// // // // ReSharper disable ArrangeTypeModifiers
// // //
// // // namespace Lessons.Architecture.Basics
// // // {
// // //     interface IQuestManager
// // //     {
// // //         event Action<IQuest> OnQuestTaken;
// // //
// // //         event Action<IQuest> OnQuestStarted;
// // //
// // //         event Action<IQuest> OnQuestCompleted;
// // //
// // //         event Action<IQuest> OnQuestRewardReceived;
// // //
// // //         IQuest CurrentQuest { get; }
// // //
// // //         bool CanTakeNewQuest();
// // //
// // //         void TakeNewQuest();
// // //
// // //         bool CanReceiveReward();
// // //
// // //         void ReceiveReward();
// // //
// // //         void SetupCurrentQuest(IQuest quest);
// // //     }
// // //
// // //
// // //     interface IPlayerService
// // //     {
// // //         GameObject GetPlayer(string playerName);
// // //
// // //         GameObject[] GetAllPlayers();
// // //     }
// // //
// // //
// // //     interface ICharacterProvider
// // //     {
// // //         ICharacter Character { get; }
// // //     }
// // //     
// // //
// // //     
// // //     
// // //     
// // //     class MoveController
// // //     {
// // //         private readonly JoystickInput input;
// // //         private readonly ICharacter character;
// // //
// // //         public MoveController(JoystickInput input, ICharacter character) {
// // //             this.input = input;
// // //             this.character = character;
// // //         }
// // //
// // //         public void Start() {
// // //             this.input.OnDirectionMoved += this.OnMoveJoystick;
// // //         }
// // //
// // //         public void Stop() {
// // //             this.input.OnDirectionMoved -= this.OnMoveJoystick;
// // //         }
// // //
// // //         private void OnMoveJoystick(Vector2 direction) {
// // //             this.character.Move(direction);
// // //         }
// // //     }
// // //
// // //     interface ICharacter
// // //     {
// // //         void Move(Vector2 direction);
// // //     }
// // //
// // //     interface IGameSystem
// // //     {
// // //         event Action OnGameInitialized;
// // //
// // //         event Action OnGameStarted;
// // //
// // //         event Action OnGamePaused;
// // //
// // //         event Action OnGameResumed;
// // //
// // //         event Action OnGameFinished;
// // //
// // //         void InitGame();
// // //
// // //         void StartGame();
// // //
// // //         void PauseGame();
// // //
// // //         void ResumeGame();
// // //
// // //         void FinishGame();
// // //
// // //         T GetService<T>();
// // //
// // //         object GetService(Type type);
// // //
// // //         object[] GetAllServices();
// // //     }
// // //     
// // //     
// // //
// // //     public sealed class Hero : MonoBehaviour
// // //     {
// // //         public event Action<int> OnHitPointsChanged;
// // //
// // //         public int HitPonts => this.hitPoints;
// // //
// // //         [SerializeField]
// // //         private int hitPoints;
// // //
// // //         private void Awake()
// // //         {
// // //             this.Setup();
// // //         }
// // //         
// // //         public void Move()
// // //         {
// // //         }
// // //         
// // //         private void Setup()
// // //         {
// // //         }
// // //     }
// // //     
// // //     
// // //     
// // //     
// // // }
// //
// // // using System.Collections;
// // // using Game.GameEngine.Mechanics;
// // // using UnityEngine;
// // //
// // // namespace {
// // //
// // //
// // //     public sealed class UnitsModule : GameModule
// // //     {
// // //         [GameService]
// // //         private UnitsSpawner spawner = new();
// // //     
// // //         [GameService]
// // //         private UnitsDestroyer destroyer = new();
// // //     
// // //         [GameService]
// // //         private UnitsService service = new();
// // //     }
// // //
// // //
// // //
// // //     
// // //     public sealed class KillEnemyObserver
// // //     {
// // //         private Hero hero;
// // //         private MoneyStorage moneyStorage;
// // //         private AudioManager audioManager;
// // //
// // //         public void Enable() {
// // //             this.hero.OnEnemyKilled += this.OnEnemyKilled;
// // //         }
// // //
// // //         public void Disable() {
// // //             this.hero.OnEnemyKilled -= this.OnEnemyKilled;
// // //         }
// // //
// // //         private void OnEnemyKilled(Enemy enemy) {
// // //             this.moneyStorage.EarnMoney(enemy.GetReward());
// // //             this.audioManager.PlaySound(this.moneySFX);
// // //         }
// // //     }
// // //
// // //
// // //
// // //
// // //
// // //     public sealed class RespawnInteractor
// // //     {
// // //         private GameObject hero;
// // //         private float delay = 0.25f;
// // //         private Transform respawnPoint;
// // //         
// // //         public IEnumerator StartRespawn()
// // //         {
// // //             yield return new WaitForSeconds(this.delay);
// // //             this.hero.transform.position = this.respawnPoint.position;
// // //             this.hero.transform.rotation = this.respawnPoint.rotation;
// // //             this.hero.GetComponent<HitPoints>().AssignMax();
// // //         }
// // //     }
// // //



     // public sealed class AIInstaller : MonoBehaviour
     // {
     //     [SerializeField] private AI ai;
     //     
     //     [SerializeField] private Unit unit;
     //     [SerializeField] private Waypoints waypoints;
     //     [SerializeField] private float patrolPause = 1.0f;
     //     
     //     private void Awake()
     //     {
     //         this.ai.AddVariable("Unit", this.unit);
     //         this.ai.AddVariable("Waypoints", this.waypoints);
     //         this.ai.AddVariable("PatrolPause", this.patrolPause);
     //     }
     // }
     //


// // //
// // //
// // //
// // //
// // // }
// // //
// //
// //
// //
// //
// //      // public class CharacterMoveController
// //      // {
// //      //     private readonly JoystickInput input;
// //      //     private readonly ICharacter character;
// //      //
// //      //     public CharacterMoveController(JoystickInput input, ICharacter character) {
// //      //         this.input = input;
// //      //         this.character = character;
// //      //     }
// //      //
// //      //     public void Enable() {
// //      //         this.input.OnDirectionMoved += this.OnMoveJoystick;
// //      //     }
// //      //
// //      //     public void Disable() {
// //      //         this.input.OnDirectionMoved -= this.OnMoveJoystick;
// //      //     }
// //      //
// //      //     private void OnMoveJoystick(Vector2 direction) {
// //      //         this.character.Move(direction);
// //      //     }
// //      // }
// //
// // using UnityEngine;
// //
// //
// //
// //
// //
// //     public interface IKillEnemyListener {
// //         void OnEnemyKilled(Enemy enemy);
// //     }
// //
// //     public sealed class KillEnemyListener_AddReward : IKillEnemyListener {
// //         private MoneyStorage moneyStorage;
// //
// //         public void OnEnemyKilled(Enemy enemy) {
// //             this.moneyStorage.EarnMoney(enemy.GetReward());
// //         }
// //     }
// //
// //     public sealed class KillEnemyListener_PlaySound : IKillEnemyListener {
// //         private AudioManager audioManager;
// //         private AudioClip sfx;
// //
// //         public void OnEnemyKilled(Enemy enemy) {
// //             this.audioManager.PlaySound(this.sfx);
// //         }
// //     }
// //
//
// using UnityEngine;
//
//
//       public sealed class KillEnemyObserver
//       {
//           private Hero hero;
//           private MoneyStorage moneyStorage;
//           private AudioManager audioManager;
//           private AudioClip moneySFX;
//         
//           public void Enable() {
//               this.hero.OnEnemyKilled += this.OnEnemyKilled;
//           }
//       
//           public void Disable() {
//               this.hero.OnEnemyKilled -= this.OnEnemyKilled;
//           }
//       
//           private void OnEnemyKilled(Enemy enemy) {
//               this.moneyStorage.EarnMoney(enemy.GetReward());
//               this.audioManager.PlaySound(this.moneySFX);
//           }
//       }
//
// //
// //
// //
//
// // using System.Collections.Generic;
// //
// //     public interface IEffect {
// //         T GetStat<T>(string key);
// //     }
// //
// //     public interface IEffectHandler {
// //         void Apply(IEffect effect);
// //         void Discard(IEffect effect);
// //     }
// //
// //
// //     public sealed class CharacterEffector {
// //         
// //         private readonly List<IEffectHandler> handlers = new();
// //
// //         public void Apply(IEffect effect) {
// //             foreach (var handler in this.handlers) {
// //                 handler.Apply(effect);
// //             }
// //         }
// //
// //         public void Discard(IEffect effect) {
// //             foreach (var handler in this.handlers) {
// //                 handler.Discard(effect);
// //             }
// //         }
// //     }
//
//
// //
//
// public sealed class A
// {
//      public event Action OnDeath;
//
//      private List<IListener> listeners;
//      
//      public void Death()
//      {
//           //
//
//           
//           listeners.Foreach(it => )
//           OnDeath?.Invoke();
//      }
// }
