using JetBrains.Annotations;
using UnityEngine;

namespace Game.App
{
    [UsedImplicitly]
    public sealed class LanguageMediator :
        IAppInitListener,
        IAppStartListener,
        IAppQuitListener
    {
        void IAppInitListener.Init()
        {
            if (!ES3.KeyExists(nameof(LanguageData)))
            {
                return;
            }

            var language = ES3.Load<SystemLanguage>(nameof(LanguageData));
            LanguageManager.CurrentLanguage = language;
        }

        void IAppStartListener.Start()
        {
            LanguageManager.OnLanguageChanged += this.SaveLanguage;
        }

        void IAppQuitListener.OnQuit()
        {
            LanguageManager.OnLanguageChanged -= this.SaveLanguage;
        }

        private void SaveLanguage(SystemLanguage language)
        {
            ES3.Save(nameof(LanguageData), language);
        }
    }
}