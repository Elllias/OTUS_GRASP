#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace Game.Meta
{
    internal static class BoostersMenu
    {
        [MenuItem("Tools/Meta/Select Booster Catalog...")]
        private static void SelectConfig()
        {
            Selection.activeObject = Resources.Load(BoosterExtensions.BOOSTER_CATALOG_RESOURCE_PATH);
        }
    }
}
#endif