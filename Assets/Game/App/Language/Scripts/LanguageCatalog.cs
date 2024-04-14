using System;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(
        fileName = "LanguageCatalog",
        menuName = "App/Language/New LanguageCatalog"
    )]
    public sealed class LanguageCatalog : ScriptableObject
    {
        [SerializeField]
        public SystemLanguage defaultLanguage = SystemLanguage.English;
        
        [SerializeField]
        private LanguageInfo[] supportedLanguages;

        public LanguageInfo GetLanguage(int index)
        {
            return this.supportedLanguages[index];
        }

        public LanguageInfo[] GetLanguages()
        {
            return this.supportedLanguages;
        }

        public bool LanguageExists(SystemLanguage language)
        {
            for (int i = 0, count = this.supportedLanguages.Length; i < count; i++)
            {
                var info = this.supportedLanguages[i];
                if (info.language == language)
                {
                    return true;
                }
            }

            return false;
        }

        public LanguageInfo FindInfo(SystemLanguage language)
        {
            for (int i = 0, count = this.supportedLanguages.Length; i < count; i++)
            {
                var info = this.supportedLanguages[i];
                if (info.language == language)
                {
                    return info;
                }
            }

            throw new Exception($"Language info {language} is not found!");
        }
    }
}