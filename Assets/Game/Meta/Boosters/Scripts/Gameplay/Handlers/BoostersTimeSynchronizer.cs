using Game.GameEngine;

namespace Game.Meta
{
    public sealed class BoostersTimeSynchronizer : ITimeShiftHandler
    {
        private readonly BoostersManager boostersManager;

        public BoostersTimeSynchronizer(BoostersManager boostersManager)
        {
            this.boostersManager = boostersManager;
        }

        void ITimeShiftHandler.OnTimeShifted(TimeShiftReason reason, float shiftSeconds)
        {
            this.SyncBoosters(shiftSeconds);
        }

        private void SyncBoosters(float shiftSeconds)
        {
            var boosters = this.boostersManager.GetActiveBoosters();
            for (int i = 0, count = boosters.Length; i < count; i++)
            {
                var booster = boosters[i];
                booster.RemainingTime -= shiftSeconds;
            }
        }
    }
}