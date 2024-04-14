#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Game.Tutorial.Development
{
    [CreateAssetMenu(
        fileName = "DebugTutorialConfig",
        menuName = "Tutorial/New DebugTutorialConfig",
        order = 100
    )]
    public sealed class DebugTutorialConfig : ScriptableObject
    {
        private const string CONFIG_PATH = "Assets/Game/Tutorial/Debug/DebugTutorialConfig.asset";

        public static DebugTutorialConfig Instance
        {
            get { return AssetDatabase.LoadAssetAtPath<DebugTutorialConfig>(CONFIG_PATH); }
        }

        [SerializeField]
        public bool isDebug;
        
        [Space]
        [ShowIf("isDebug")]
        [SerializeField]
        public bool isCompleted;
        
        [ShowIf("isDebug")]
        [HideIf("isCompleted")]
        [SerializeField]
        public TutorialStep currentStep;
    }
}
#endif