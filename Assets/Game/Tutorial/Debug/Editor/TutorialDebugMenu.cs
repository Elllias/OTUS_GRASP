using UnityEditor;

#if UNITY_EDITOR
namespace Game.Tutorial.Development
{
    public static class TutorialDebugMenu
    {
        [MenuItem("Debug/Select Tutorial Config...", priority = 55)]
        public static void SelectDebugConfig()
        {
            Selection.activeObject = DebugTutorialConfig.Instance;
        }
    }
}
#endif