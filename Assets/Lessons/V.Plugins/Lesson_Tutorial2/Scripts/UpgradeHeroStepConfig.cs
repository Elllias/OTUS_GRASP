using Game.Meta;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Lessons.Plugins.Lesson_Tutorial2
{
    [CreateAssetMenu(
        fileName = "New Tutorial Step «Upgrade Hero»",
        menuName = "Lessons/New Tutorial Step «Upgrade Hero»"
    )]
    public sealed class UpgradeHeroStepConfig : ScriptableObject
    {
        [Title("Upgrade")]
        [SerializeField]
        public UpgradeConfig targetUpgrade;

        [SerializeField]
        public int targetLevel;

        [Title("UI")]
        [SerializeField]
        public string title;

        [SerializeField]
        public Sprite icon;
    }
}