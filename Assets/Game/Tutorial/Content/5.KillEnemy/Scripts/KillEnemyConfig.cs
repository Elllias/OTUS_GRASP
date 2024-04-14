using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Kill Enemy»",
        menuName = "Tutorial/New Config «Kill Enemy»"
    )]
    public sealed class KillEnemyConfig : ScriptableObject
    {
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title = "KILL ENEMY";

        [SerializeField]
        public Sprite icon;
    }
}