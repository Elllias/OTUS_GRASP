#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Game.Meta
{
    internal static class MissionsMenu
    {
        [MenuItem("Tools/Meta/Select Mission Catalog...")]
        private static void SelectConfig()
        {
            Selection.activeObject = Resources.Load(MissionExtensions.MISSION_CATALOG_RESOURCE_PATH);
        }
    }
}
#endif