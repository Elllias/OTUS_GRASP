using Game.App;
using LocalizationModule;
using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Local

namespace Game.Localization
{
    public class LocalizationComponent : MonoBehaviour
    {
        [SerializeReference]
        private ILanguageHandler[] children = new ILanguageHandler[0];

        protected virtual void OnEnable()
        {
            this.UpdateLanguage(LanguageManager.CurrentLanguage);
            LanguageManager.OnLanguageChanged += this.UpdateLanguage;
        }

        protected virtual void OnDisable()
        {
            LanguageManager.OnLanguageChanged -= this.UpdateLanguage;
        }

        protected virtual void UpdateLanguage(SystemLanguage language)
        {
            for (int i = 0, count = this.children.Length; i < count; i++)
            {
                var handler = this.children[i];
                handler.UpdateLanguage(language);
            }
        }
    }
}