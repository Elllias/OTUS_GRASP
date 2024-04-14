using Services;

namespace Game.App
{
    public sealed class RealtimeClockSaver : 
        IAppStartListener,
        IAppQuitListener
    {
        [ServiceInject]
        private RealtimePreferences preferences;

        [ServiceInject]
        private RealtimeClock realtimeClock;
        
        void IAppStartListener.Start()
        {
            this.realtimeClock.OnPaused += this.SaveSession;
            this.realtimeClock.OnEnded += this.SaveSession;
        }

        void IAppQuitListener.OnQuit()
        {
            this.realtimeClock.OnPaused -= this.SaveSession;
            this.realtimeClock.OnEnded -= this.SaveSession;
        }

        private void SaveSession()
        {
            var data = new RealtimeData
            {
                nowSeconds = this.realtimeClock.RealtimeSeconds
            };
            this.preferences.SaveData(data);
        }
    }
}