// using System;
// using System.Collections.Generic;
// using Sirenix.OdinInspector;
// using UnityEngine;
//
// namespace Lessons.Architecture.DI
// {
//     public sealed class GameSystem : MonoBehaviour
//     {
//         [SerializeField]
//         private bool autoRun = true;
//         
//         public GameSystem()
//         {
//             this.injector = new GameInjector(this.serviceLocator);
//         }
//         
//         #region GameListeners
//
//         [ShowInInspector, ReadOnly]
//         public GameState State
//         {
//             get { return this.gameMachine.State; }
//         }
//
//         private readonly GameMachine gameMachine = new GameMachine();
//
//         private void Start()
//         {
//             if (this.autoRun)
//             {
//                 this.InitGame();
//                 this.StartGame();
//             }
//         }
//
//         private void Update()
//         {
//             this.gameMachine.Update();
//         }
//
//         private void FixedUpdate()
//         {
//             this.gameMachine.FixedUpdate();
//         }
//
//         private void LateUpdate()
//         {
//             this.gameMachine.LateUpdate();
//         }
//
//         public void AddListener(IGameListener listener)
//         {
//             this.gameMachine.AddListener(listener);
//         }
//         
//         public void AddListeners(IEnumerable<IGameListener> listeners)
//         {
//             this.gameMachine.AddListeners(listeners);
//         }
//         
//         public void RemoveListener(IGameListener listener)
//         {
//             this.gameMachine.RemoveListener(listener);
//         }
//
//         [Button]
//         public void InitGame()
//         {
//             this.gameMachine.InitGame();
//         }
//
//         [Button]
//         public void StartGame()
//         {
//             this.gameMachine.StartGame();
//         }
//
//         [Button]
//         public void PauseGame()
//         {
//             this.gameMachine.PauseGame();
//         }
//
//         [Button]
//         public void ResumeGame()
//         {
//             this.gameMachine.ResumeGame();
//         }
//
//         [Button]
//         public void FinishGame()
//         {
//             this.gameMachine.FinishGame();
//         }
//
//         #endregion
//
//         #region ServiceLocator
//
//         private readonly GameLocator serviceLocator = new GameLocator();
//
//         public List<T> GetServices<T>()
//         {
//             return this.serviceLocator.GetServices<T>();
//         }
//
//         public object GetService(Type serviceType)
//         {
//             return this.serviceLocator.GetService(serviceType);
//         }
//
//         public T GetService<T>()
//         {
//             return this.serviceLocator.GetService<T>();
//         }
//
//         public void AddService(object service)
//         {
//             this.serviceLocator.AddService(service);
//         }
//         
//         public void AddServices(IEnumerable<object> services)
//         {
//             this.serviceLocator.AddServices(services);
//         }
//
//         #endregion
//
//         #region DependencyInjection
//
//         private readonly GameInjector injector;
//
//         public void Inject(object target)
//         {
//             this.injector.Inject(target);
//         }
//
//         #endregion
//     }
// }