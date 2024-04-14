namespace Game.App
{
    public static class DatabaseConfig
    {
        public const string DATABASE_NAME = "unitypro.db";

        public const int DATABASE_VERSION = 1;

        internal static string SourcePath
        {
            get
            {
                string sourcePath;
#if UNITY_EDITOR
                sourcePath = $"{UnityEngine.Application.dataPath}/StreamingAssets/{DATABASE_NAME}";
#elif UNITY_ANDROID
                sourcePath = $"jar:file://{UnityEngine.Application.dataPath}!/assets/{DATABASE_NAME}";
#endif
                return sourcePath;
            }
        }

        internal static string DestinationPath
        {
            get
            {
                string destinationPath;
#if UNITY_EDITOR
                destinationPath = $"{UnityEngine.Application.dataPath}/Tools/Database/{DATABASE_NAME}";
#elif UNITY_ANDROID
                destinationPath = $"{UnityEngine.Application.persistentDataPath}/{DATABASE_NAME}";
#endif
                return destinationPath;
            }
        }
    }
}