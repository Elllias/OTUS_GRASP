using Game.App;
using Services;

namespace Game.Analytics
{
    public sealed class ApplicationAnalyticsTracker : 
        IAppStartListener,
        IAppQuitListener
    {
        [ServiceInject]
        private ApplicationManager applicationManager;

        void IAppStartListener.Start()
        {
            this.applicationManager.OnPaused += this.OnAppPaused;
            this.applicationManager.OnResumed += this.OnAppResumed;
            this.applicationManager.OnQuit += this.OnAppQuit;
            
            ApplicationAnalytics.LogApplicationStarted();
        }

        void IAppQuitListener.OnQuit()
        {
            this.applicationManager.OnPaused -= this.OnAppPaused;
            this.applicationManager.OnResumed -= this.OnAppResumed;
            this.applicationManager.OnQuit -= this.OnAppQuit;
        }

        private void OnAppPaused()
        {
            ApplicationAnalytics.LogApplicationPaused();
        }

        private void OnAppResumed()
        {
            ApplicationAnalytics.LogApplicationResumed();
        }

        private void OnAppQuit()
        {
            ApplicationAnalytics.LogApplicationExited();
        }
    }
}