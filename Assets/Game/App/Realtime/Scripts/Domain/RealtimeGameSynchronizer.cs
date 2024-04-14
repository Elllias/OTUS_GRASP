using Game.GameEngine;
using Services;

namespace Game.App
{
    public sealed class RealtimeGameSynchronizer : 
        IAppStartListener,
        IAppQuitListener
    {
        [ServiceInject]
        private GameFacade gameFacade;
        
        [ServiceInject]
        private RealtimeClock realtimeClock;

        void IAppStartListener.Start()
        {
            this.realtimeClock.OnStarted += this.OnSessionStarted;
            this.realtimeClock.OnResumed += this.OnSessionResumed;
        }

        void IAppQuitListener.OnQuit()
        {
            this.realtimeClock.OnStarted -= this.OnSessionStarted;
            this.realtimeClock.OnResumed -= this.OnSessionResumed;
        }

        private void OnSessionStarted(long pauseSeconds)
        {
            if (pauseSeconds > 0)
            {
                this.gameFacade
                    .GetService<TimeShiftEmitter>()
                    .EmitEvent(TimeShiftReason.START_GAME, pauseSeconds);
            }
        }

        private void OnSessionResumed(long pauseSeconds)
        {
            if (pauseSeconds > 0)
            {
                this.gameFacade
                    .GetService<TimeShiftEmitter>()
                    .EmitEvent(TimeShiftReason.RESUME_GAME, pauseSeconds);
            }
        }
    }
}