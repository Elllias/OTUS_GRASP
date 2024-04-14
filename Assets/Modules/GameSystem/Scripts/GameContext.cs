using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    [AddComponentMenu("GameSystem/Game Сontext")]
    [DisallowMultipleComponent]
    public class GameContext : MonoBehaviour
    {
        public enum State
        {
            OFF = 1,
            CONSTRUCT = 2,
            INIT = 3,
            READY = 4,
            PLAY = 5,
            PAUSE = 6,
            FINISH = 7
        }
        
        public event Action OnGameConstructed;
        
        public event Action OnGameInitialized;

        public event Action OnGameReady;

        public event Action OnGameStarted;

        public event Action OnGamePaused;

        public event Action OnGameResumed;

        public event Action OnGameFinished;

        public State CurrentState { get; protected set; }

        [SerializeField]
        private bool autoRun = true;
        
        [SerializeField, Space]
        private List<MonoBehaviour> gameServices = new();

        [SerializeField, Space]
        private List<MonoBehaviour> gameElements = new();

        [SerializeField, Space]
        private List<ConstructTask> constructTasks = new();

        private readonly ElementContext elementContext;

        private readonly ServiceContext serviceContext;

        public GameContext()
        {
            this.CurrentState = State.OFF;
            this.elementContext = new ElementContext(this);
            this.serviceContext = new ServiceContext();
        }

        private void Awake()
        {
            if (this.autoRun)
            {
                this.StartCoroutine(this.AutoRun());
            }
            else
            {
                this.enabled = false;
            }
        }

        private void FixedUpdate()
        {
            this.elementContext.FixedUpdate(Time.fixedDeltaTime);
        }

        private void Update()
        {
            this.elementContext.Update(Time.deltaTime);
        }

        private void LateUpdate()
        {
            this.elementContext.LateUpdate(Time.deltaTime);
        }

        [ContextMenu("Construct Game")]
        public void ConstructGame()
        {
            if (this.CurrentState != State.OFF)
            {
                LogWarning($"Can't construct the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.OFF)}");
                return;
            }
            
            this.RegisterElements();
            this.RegisterServices();
            
            this.CurrentState = State.CONSTRUCT;
            this.elementContext.ConstructGame();

            foreach (var task in this.constructTasks)
            {
                task.Construct(this);
            }

            this.OnGameConstructed?.Invoke();
        }

        [ContextMenu("Init Game")]
        public void InitGame()
        {
            if (this.CurrentState != State.CONSTRUCT)
            {
                LogWarning($"Can't initialize the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.CONSTRUCT)}");
                return;
            }

            this.CurrentState = State.INIT;
            this.elementContext.InitGame();
            this.OnGameInitialized?.Invoke();
        }

        [ContextMenu("Ready Game")]
        public void ReadyGame()
        {
            if (this.CurrentState != State.INIT)
            {
                LogWarning($"Can't set ready the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.INIT)}");
                return;
            }

            this.CurrentState = State.READY;
            this.elementContext.ReadyGame();
            this.OnGameReady?.Invoke();
        }

        [ContextMenu("Start Game")]
        public void StartGame()
        {
            if (this.CurrentState != State.READY)
            {
                LogWarning($"Can't start the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.READY)}");
                return;
            }

            this.CurrentState = State.PLAY;
            this.elementContext.StartGame();
            this.OnGameStarted?.Invoke();
            
            this.enabled = true;
        }

        [ContextMenu("Pause Game")]
        public void PauseGame()
        {
            if (this.CurrentState != State.PLAY)
            {
                LogWarning($"Can't pause the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.PLAY)}");
                return;
            }

            this.CurrentState = State.PAUSE;
            this.elementContext.PauseGame();
            this.OnGamePaused?.Invoke();
            
            this.enabled = false;
        }

        [ContextMenu("Resume Game")]
        public void ResumeGame()
        {
            if (this.CurrentState != State.PAUSE)
            {
                LogWarning($"Can't resume the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.PAUSE)}");
                return;
            }

            this.CurrentState = State.PLAY;
            this.elementContext.ResumeGame();
            this.OnGameResumed?.Invoke();
            
            this.enabled = true;
        }

        [ContextMenu("Finish Game")]
        public void FinishGame()
        {
            if (this.CurrentState is not (State.PLAY or State.PAUSE))
            {
                LogWarning($"Can't finish the game from the {this.CurrentState} state, " +
                           $"only from {nameof(State.PLAY)} or {nameof(State.PAUSE)}");
                return;
            }

            this.CurrentState = State.FINISH;
            this.elementContext.FinishGame();
            this.OnGameFinished?.Invoke();

            this.enabled = false;
        }

        private void RegisterElements()
        {
            for (int i = 0, count = this.gameElements.Count; i < count; i++)
            {
                var monoElement = this.gameElements[i];
                if (monoElement is IGameElement gameElement)
                {
                    this.RegisterElement(gameElement);
                }
            }
        }

        private void RegisterServices()
        {
            for (int i = 0, count = this.gameServices.Count; i < count; i++)
            {
                var monoService = this.gameServices[i];
                if (monoService != null)
                {
                    this.RegisterService(monoService);
                }
            }
        }

        private IEnumerator AutoRun()
        {
            yield return new WaitForEndOfFrame();
            this.ConstructGame();
            this.InitGame();
            this.ReadyGame();
            this.StartGame();
        }

#if UNITY_EDITOR
        public void Editor_AddElement(MonoBehaviour gameElement)
        {
            this.gameElements.Add(gameElement);
        }

        public void Editor_AddService(MonoBehaviour gameService)
        {
            this.gameServices.Add(gameService);
        }

        public void Editor_AddConstructTask(ConstructTask task)
        {
            this.constructTasks.Add(task);
        }

        private void OnValidate()
        {
            EditorValidator.ValidateServices(ref this.gameServices);
            EditorValidator.ValidateElements(ref this.gameElements);
        }
#endif

        public void RegisterElement(IGameElement element)
        {
            this.elementContext.AddElement(element);
        }

        public void UnregisterElement(IGameElement element)
        {
            this.elementContext.RemoveElement(element);
        }

        public object[] GetAllElements()
        {
            return this.elementContext.GetAllElements();
        }

        public void RegisterService(object service)
        {
            this.serviceContext.AddService(service);
        }

        public void UnregisterService(object service)
        {
            this.serviceContext.RemoveService(service);
        }

        public T GetService<T>()
        {
            return this.serviceContext.GetService<T>();
        }

        public object[] GetServices(Type type)
        {
            return this.serviceContext.GetServices(type);
        }

        public object[] GetAllServices()
        {
            return this.serviceContext.GetAllServices().ToArray();
        }

        public object GetService(Type type)
        {
            return this.serviceContext.GetService(type);
        }

        public bool TryGetService<T>(out T service)
        {
            return this.serviceContext.TryGetService(out service);
        }

        public bool TryGetService(Type type, out object service)
        {
            return this.serviceContext.TryGetService(type, out service);
        }

        public T[] GetServices<T>()
        {
            return this.serviceContext.GetServices<T>();
        }
        
        public abstract class ConstructTask : ScriptableObject
        {
            public abstract void Construct(GameContext gameContext);
        }

        private static void LogWarning(string message)
        {
#if UNITY_EDITOR
            Debug.LogWarning(message);
#endif
        }
    }
}