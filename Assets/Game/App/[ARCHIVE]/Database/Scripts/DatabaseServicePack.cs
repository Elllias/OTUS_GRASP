using System.Collections.Generic;
using Services;
using SqliteModule;
using UnityEngine;

namespace Game.App
{
    [CreateAssetMenu(
        fileName = "Database Service Pack",
        menuName = "App/Database/New Database Service Pack"
    )]
    public sealed class DatabaseServicePack : ServicePackBase
    {
        private SqliteDatabase database;

        private SqliteDatabaseInstaller databaseInstaller;

        private SqliteDatabaseUpdater databaseUpdater;
        
        public override IEnumerable<object> ProvideServices()
        {
            var dbPath = $"URI=file:{DatabaseConfig.DestinationPath}";
            this.database = new SqliteDatabase(dbPath);

            var adapter = new DatabaseAdapter();
            this.databaseInstaller = new SqliteDatabaseInstaller(adapter);
            this.databaseUpdater = new SqliteDatabaseUpdater(this.database, adapter);

            yield return this.database;
            yield return this.databaseInstaller;
            yield return this.databaseUpdater;
        }
    }
}