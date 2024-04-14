using System;
using Declarative;
using Lessons.Utils;
using Services;
using SqliteModule;
using UnityEngine;

namespace Game.App
{
    public sealed class LoadingTask_ConnectToDatabase : ILoadingTask
    {
        private readonly SqliteDatabase database;

        [ServiceInject]
        public LoadingTask_ConnectToDatabase(SqliteDatabase database)
        {
            this.database = database;
        }

        public async void Do(Action<LoadingResult> callback)
        {
            if (await this.database.ConnectAsync())
            {
                callback?.Invoke(LoadingResult.Success());
            }
            else
            {
                callback?.Invoke(LoadingResult.Fail("Can't connect to database!"));
            }
        }
    }
}