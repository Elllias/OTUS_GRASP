#if UNITY_EDITOR
using UnityEditor;

namespace Game.UnityEditor
{
    public class LanguageMenu
    {
        [MenuItem("Tools/Language/Select Config", priority = 100)]
        private static void SelectConfig()
        {
            const string path =
                "Assets/MyLittleUniverse/App/Language/Resources/LanguageConfig.asset";
            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(path);
        }
    }
}
#endif