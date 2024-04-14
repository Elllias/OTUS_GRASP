using SqliteModule;
using UnityEngine;

namespace Game.App
{
    internal sealed class DatabaseAdapter :
        SqliteDatabaseInstaller.IAdapter,
        SqliteDatabaseUpdater.IAdapter
    {
        private const string INSTALLED_KEY = "db_prefs/is_installed";

        private const string VERSION_KEY = "db_prefs/current_version";

        bool SqliteDatabaseInstaller.IAdapter.IsInstalled
        {
            get => PlayerPrefs.HasKey(INSTALLED_KEY) && PlayerPrefs.GetInt(INSTALLED_KEY) == 1;
            set => PlayerPrefs.SetInt(INSTALLED_KEY, value ? 1 : 0);
        }

        string SqliteDatabaseInstaller.IAdapter.SourceFilePath
        {
            get { return DatabaseConfig.SourcePath; }
        }

        string SqliteDatabaseInstaller.IAdapter.DestinationFilePath
        {
            get { return DatabaseConfig.DestinationPath; }
        }
        
        int SqliteDatabaseUpdater.IAdapter.CurrentVersion
        {
            get { return PlayerPrefs.GetInt(VERSION_KEY); }
            set { PlayerPrefs.SetInt(VERSION_KEY, value); }
        }

        int SqliteDatabaseUpdater.IAdapter.TargetVersion
        {
            get { return DatabaseConfig.DATABASE_VERSION; }
        }
    }
}