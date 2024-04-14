using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Welcome»",
        menuName = "Tutorial/New Config «Welcome»"
    )]
    public sealed class WelcomeConfig : ScriptableObject
    {
        [TranslationKey]
        [SerializeField]
        public string title;

        [TranslationKey]
        [SerializeField]
        public string description;
    }
}