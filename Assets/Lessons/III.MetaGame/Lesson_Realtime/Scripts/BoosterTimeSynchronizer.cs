using GameSystem;
using UnityEngine;

namespace Lessons.MetaGame.Lesson_Boosters
{
    public sealed class BoosterTimeSynchronizer : MonoBehaviour,
        ITimeShiftListener,
        IGameReadyElement,
        IGameFinishElement
    {
        [GameInject]
        private BoostersManager boostersManager;

        [GameInject]
        private TimeShifter timeShifter;

        void ITimeShiftListener.OnTimeShifted(float secondOffset)
        {
            foreach (var booster in this.boostersManager.GetActiveBoosters())
            {
                booster.RemainingSeconds -= secondOffset;
            }

            Debug.Log("On Boosters Shifted!");
        }

        void IGameReadyElement.ReadyGame()
        {
            this.timeShifter.AddListener(this);
        }

        void IGameFinishElement.FinishGame()
        {
            this.timeShifter.RemoveListener(this);
        }
    }
}