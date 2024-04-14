using Game.App;
using GameSystem;
using UnityEngine;

namespace Game.GameEngine
{
    public sealed class PauseGameController_TimeScale : MonoBehaviour, 
        IGamePauseElement,
        IGameResumeElement
    {
        private const float PAUSE_SCALE = 0;

        private const float RESUME_SCALE = 1;
        
        void IGamePauseElement.PauseGame()
        {
            TimeScaleManager.SetScale(PAUSE_SCALE);
        }

        void IGameResumeElement.ResumeGame()
        {
            TimeScaleManager.SetScale(RESUME_SCALE);
        }
    }
}