namespace Game.App
{
    public sealed class RealtimePreferences
    {
        private const string PREFS_KEY = "UserSessionData";
     
        public bool LoadData(out RealtimeData data)
        {
            if (ES3.KeyExists(PREFS_KEY))
            {
                data = ES3.Load<RealtimeData>(PREFS_KEY);
                return true;
            }

            data = default;
            return false;
        }

        public void SaveData(RealtimeData data)
        {
            ES3.Save(PREFS_KEY, data);
        }
    }
}