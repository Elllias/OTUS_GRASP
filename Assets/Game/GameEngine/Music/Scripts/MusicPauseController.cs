using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class MusicPauseController : MonoBehaviour,
        IGamePauseElement,
        IGameResumeElement
    {
        void IGamePauseElement.PauseGame()
        {
            MusicManager.Pause();
        }

        void IGameResumeElement.ResumeGame()
        {
            MusicManager.Resume();
        }
    }
}