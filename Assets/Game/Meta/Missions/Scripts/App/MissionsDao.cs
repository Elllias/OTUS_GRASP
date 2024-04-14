using System.Collections.Generic;
using JetBrains.Annotations;
using Services;
using SqliteModule;

namespace Game.Meta
{
    //EXAMPLE OF SQLITE ORM
    [UsedImplicitly]
    public sealed class MissionsDao
    {
        private SqliteDatabase database;

        [ServiceInject]
        public void Construct(SqliteDatabase database)
        {
            this.database = database;
        }
        
        public bool SelectMissions(out List<MissionData> missions)
        {
            missions = new List<MissionData>();
            return this.database.SelectQuery("SELECT * FROM missions", missions, reader => new MissionData
            {
                id = reader.GetString(0),
                serializedState = reader.GetString(1)
            });
        }

        public void DeleteMissions()
        {
            this.database.DeleteQuery("DELETE FROM missions");
        }

        public void InsertMissions(MissionData[] missions)
        {
            var serializedMissions = SqliteSerializer.Serialize(missions, data => new SqliteSerializer.Params(
                data.id,
                data.serializedState
            ));
            var command = string.Format("INSERT INTO missions (id, state) VALUES {0}", serializedMissions);
            this.database.InsertQuery(command);
        }
    }
}