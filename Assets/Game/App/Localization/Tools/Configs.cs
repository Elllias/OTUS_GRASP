#if UNITY_EDITOR
using UnityEngine;

namespace Game.Localization.UnityEditor
{
    public static class Configs
    {
        public static LocalizationTextConfig TextConfig
        {
            get { return Resources.Load<LocalizationTextConfig>("LocalizationTextConfig"); }
        }

        public static LocalizationSpriteConfig SpriteConfig
        {
            get { return Resources.Load<LocalizationSpriteConfig>("LocalizationSpriteConfig"); }
        }

        public static LocalizationAudioClipConfig AudioClipConfig
        {
            get { return Resources.Load<LocalizationAudioClipConfig>("LocalizationAudioClipConfig"); }
        }       
    }
}
#endif