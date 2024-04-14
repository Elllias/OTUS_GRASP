namespace Game.App
{
    public interface IAnalyticsLogger
    {
        void LogEvent(string eventName, params AnalyticsParameter[] parameters);
    }
}