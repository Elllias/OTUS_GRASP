using TMPro;
using UnityEngine;

namespace Lessons.Plugins.LocalizationLesson
{
    [DefaultExecutionOrder(-1000)]
    public sealed class LocalizationManager : MonoBehaviour
    {
        private static LocalizationManager instance;
        
        [SerializeField]
        private LocalizationDictionary<string> textDictionary;

        [SerializeField]
        private LocalizationDictionary<Sprite> spriteDictionary;

        [SerializeField]
        private LocalizationDictionary<AudioClip> audioDictionary;

        [SerializeField]
        private LocalizationConfig config;

        private void Awake()
        {
            instance = this;
        }

        public static string GetText(string key, SystemLanguage language)
        {
            return instance.textDictionary.GetTranslation(key, language);
        }

        public static Sprite GetSprite(string imageKey, SystemLanguage language)
        {
            return instance.spriteDictionary.GetTranslation(imageKey, language);
        }

        public static TMP_FontAsset GetFont(SystemLanguage language)
        {
            return instance.config.fonts.FindValue(language);
        }

        public static AudioClip GetAudio(string key, SystemLanguage language)
        {
            return instance.audioDictionary.GetTranslation(key, language);
        }

        public static int GetFontSizeMedium(SystemLanguage language)
        {
            return instance.config.fontSizes.FindValue(language);
        }
    }
}