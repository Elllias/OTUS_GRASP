using Game.Localization;
using UnityEngine;

namespace Game.Tutorial
{
    [CreateAssetMenu(
        fileName = "Config «Congratulations»",
        menuName = "Tutorial/New Config «Congratulations»"
    )]
    public sealed class CongratulationsConfig : ScriptableObject
    {
        [Header("Meta")]
        [TranslationKey]
        [SerializeField]
        public string title;

        [TranslationKey]
        [SerializeField]
        public string description;
    }
}