#if UNITY_EDITOR
using UnityEditor;

namespace Game.Gameplay.Player
{
    internal static class MoneyMenu
    {
        [MenuItem("Debug/Select Money Config...")]
        private static void SelectConfig()
        {
            Selection.activeObject = DebugMoneyConfig.LoadAsset();
        }
    }
}
#endif