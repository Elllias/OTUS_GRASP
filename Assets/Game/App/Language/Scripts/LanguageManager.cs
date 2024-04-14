using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.App
{
    public sealed class LanguageManager : MonoBehaviour
    {
        public static event Action<SystemLanguage> OnLanguageChanged;

        public static SystemLanguage CurrentLanguage
        {
            get { return GetCurrentLanguage(); }
            set { SetCurrentLanguage(value); }
        }

        private static LanguageManager instance;

        [ReadOnly]
        [ShowInInspector]
        [PropertyOrder(-10)]
        private SystemLanguage currentLanguage = default;

        [SerializeField]
        private LanguageCatalog languageCatalog;

        public static void SetCurrentLanguage(int index)
        {
            if (instance == null)
            {
                return;
            }

            var languageInfo = instance.languageCatalog.GetLanguage(index);
            var language = languageInfo.language;
            instance.currentLanguage = language;
            OnLanguageChanged?.Invoke(language);
        }

        public static LanguageInfo[] GetLanguages()
        {
            if (instance != null)
            {
                return instance.languageCatalog.GetLanguages();
            }

            return new LanguageInfo[0];
        }

        public static LanguageInfo GetLanguage(int index)
        {
            if (instance == null)
            {
                return default;
            }

            return instance.languageCatalog.GetLanguage(index);
        }

        private void Awake()
        {
            if (instance != null)
            {
                throw new Exception("Instance is already created!");
            }

            instance = this;
            this.Initialize();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        private void Initialize()
        {
            var systemLanguage = Application.systemLanguage;
            if (this.languageCatalog.LanguageExists(systemLanguage))
            {
                this.currentLanguage = systemLanguage;
            }
            else
            {
                this.currentLanguage = this.languageCatalog.defaultLanguage;
            }
        }

        private static SystemLanguage GetCurrentLanguage()
        {
            if (instance == null)
            {
                return default;
            }

            return instance.currentLanguage;
        }

        private static void SetCurrentLanguage(SystemLanguage language)
        {
            if (instance == null)
            {
                return;
            }

            if (!instance.languageCatalog.LanguageExists(language))
            {
                throw new Exception($"Language {language} is not supported!");
            }

            instance.currentLanguage = language;
            OnLanguageChanged?.Invoke(language);
        }

#if UNITY_EDITOR
        [PropertySpace(10)]
        [Button("Set Language")]
        private void Editor_SetLanguage(SystemLanguage language)
        {
            SetCurrentLanguage(language);
        }
#endif
    }
}