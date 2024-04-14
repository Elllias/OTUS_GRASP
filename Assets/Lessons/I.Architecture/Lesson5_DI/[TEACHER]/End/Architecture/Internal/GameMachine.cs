// using System.Collections.Generic;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     internal sealed class GameMachine
//     {
//         [ShowInInspector, ReadOnly]
//         internal GameState State
//         {
//             get { return this.state; }
//         }
//
//         private GameState state;
//
//         private readonly List<IGameListener> listeners = new();
//
//         private readonly List<IGameUpdateListener> updateListeners = new();
//         
//         private readonly List<IGameFixedUpdateListener> fixedUpdateListeners = new();
//         
//         private readonly List<IGameLateUpdateListener> lateUpdateListeners = new();
//
//         internal void Update()
//         {
//             if (this.state != GameState.PLAYING)
//             {
//                 return;
//             }
//
//             var deltaTime = Time.deltaTime;
//             for (int i = 0, count = this.updateListeners.Count; i < count; i++)
//             {
//                 var listener = this.updateListeners[i];
//                 listener.OnUpdate(deltaTime);
//             }
//         }
//
//         internal void FixedUpdate()
//         {
//             if (this.state != GameState.PLAYING)
//             {
//                 return;
//             }
//             
//             var deltaTime = Time.fixedDeltaTime;
//             for (int i = 0, count = this.fixedUpdateListeners.Count; i < count; i++)
//             {
//                 var listener = this.fixedUpdateListeners[i];
//                 listener.OnFixedUpdate(deltaTime);
//             }
//         }
//
//         internal void LateUpdate()
//         {
//             if (this.state != GameState.PLAYING)
//             {
//                 return;
//             }
//             
//             var deltaTime = Time.deltaTime;
//             for (int i = 0, count = this.lateUpdateListeners.Count; i < count; i++)
//             {
//                 var listener = this.lateUpdateListeners[i];
//                 listener.OnLateUpdate(deltaTime);
//             }
//         }
//         
//         internal void AddListeners(IEnumerable<IGameListener> gameListeners)
//         {
//             foreach (var listener in gameListeners)
//             {
//                 this.AddListener(listener);
//             }
//         }
//         
//         internal void AddListener(IGameListener listener)
//         {
//             if (listener == null)
//             {
//                 return;
//             }
//             
//             this.listeners.Add(listener);
//
//             if (listener is IGameUpdateListener updateListener)
//             {
//                 this.updateListeners.Add(updateListener);
//             }
//
//             if (listener is IGameFixedUpdateListener fixedUpdateListener)
//             {
//                 this.fixedUpdateListeners.Add(fixedUpdateListener);
//             }
//
//             if (listener is IGameLateUpdateListener lateUpdateListener)
//             {
//                 this.lateUpdateListeners.Add(lateUpdateListener);
//             }
//         }
//
//
//         internal void RemoveListener(IGameListener listener)
//         {
//             if (listener == null)
//             {
//                 return;
//             }
//             
//             this.listeners.Remove(listener);
//
//             if (listener is IGameUpdateListener updateListener)
//             {
//                 this.updateListeners.Remove(updateListener);
//             }
//
//             if (listener is IGameFixedUpdateListener fixedUpdateListener)
//             {
//                 this.fixedUpdateListeners.Remove(fixedUpdateListener);
//             }
//
//             if (listener is IGameLateUpdateListener lateUpdateListener)
//             {
//                 this.lateUpdateListeners.Remove(lateUpdateListener);
//             }
//         }
//
//         internal void InitGame()
//         {
//             foreach (var listener in this.listeners)
//             {
//                 if (listener is IGameInitListener initListener)
//                 {
//                     initListener.OnInit();
//                 }
//             }
//         }
//
//         internal void StartGame()
//         {
//             foreach (var listener in this.listeners)
//             {
//                 if (listener is IGameStartListener startListener)
//                 {
//                     startListener.OnStartGame();
//                 }
//             }
//
//             this.state = GameState.PLAYING;
//         }
//
//         internal void PauseGame()
//         {
//             foreach (var listener in this.listeners)
//             {
//                 if (listener is IGamePauseListener pauseListener)
//                 {
//                     pauseListener.OnPauseGame();
//                 }
//             }
//             
//             this.state = GameState.PAUSED;
//         }
//
//         internal void ResumeGame()
//         {
//             foreach (var listener in this.listeners)
//             {
//                 if (listener is IGameResumeListener resumeListener)
//                 {
//                     resumeListener.OnResumeGame();
//                 }
//             }
//             
//             this.state = GameState.PLAYING;
//         }
//
//         internal void FinishGame()
//         {
//             foreach (var listener in this.listeners)
//             {
//                 if (listener is IGameFinishListener finishListener)
//                 {
//                     finishListener.OnFinishGame();
//                 }
//             }
//             
//             this.state = GameState.FINISHED;
//         }
//
//    
//     }
// }