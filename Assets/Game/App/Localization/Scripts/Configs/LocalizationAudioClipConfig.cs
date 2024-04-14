using LocalizationModule;
using UnityEngine;

namespace Game.Localization
{
    [CreateAssetMenu(
        fileName = "LocalizationAudioClipConfig",
        menuName = "Localization/New LocalizationAudioClipConfig"
    )]
    public sealed class LocalizationAudioClipConfig : ScriptableObject
    {
        [SerializeField]
        public AudioClipEntity[] entities;
    }
}