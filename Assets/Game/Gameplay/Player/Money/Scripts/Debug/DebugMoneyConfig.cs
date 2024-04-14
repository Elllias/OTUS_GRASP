#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game.Gameplay.Player
{
    [CreateAssetMenu(
        fileName = "DebugMoneyConfig",
        menuName = "Gameplay/Player/New DebugMoneyConfig"
    )]
    public sealed class DebugMoneyConfig : ScriptableObject
    {
        private const string path = "Assets/Game/Gameplay/Player/Money/Editor/DebugMoneyConfig.asset";

        [SerializeField]
        public bool debugMode;

        [ShowIf("debugMode")]
        [SerializeField]
        public int money;

        public static DebugMoneyConfig LoadAsset()
        {
            return AssetDatabase.LoadAssetAtPath<DebugMoneyConfig>(path);
        }
    }
}
#endif