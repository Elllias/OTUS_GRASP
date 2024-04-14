#if UNITY_EDITOR
using GameSystem;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Game.GameEngine.Development
{
    public sealed class DebugContext : MonoBehaviour
    {
        [SerializeField]
        private bool debugMode;

        [Header("Events")]
        [FormerlySerializedAs("onLocalMode")]
        [SerializeField]
        private UnityEvent onDebugMode;

        [FormerlySerializedAs("onGlobalMode")]
        [SerializeField]
        private UnityEvent onReleaseMode;

        private void Awake()
        {
            if (this.debugMode)
            {
                this.onDebugMode.Invoke();
            }
            else
            {
                this.onReleaseMode?.Invoke();
            }
        }

        private void Start()
        {
            if (!this.debugMode)
            {
                return;
            }

            var gameContext = FindObjectOfType<GameContext>();
            gameContext.ConstructGame();
            gameContext.InitGame();
            gameContext.ReadyGame();
            gameContext.StartGame();
        }
    }
}
#endif