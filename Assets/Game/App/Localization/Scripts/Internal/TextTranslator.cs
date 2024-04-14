using System.Collections.Generic;
using LocalizationModule;
using UnityEngine;

namespace Game.Localization
{
    public sealed class TextTranslator : ITranslator<string>
    {
        private readonly Dictionary<string, ITranslator<string>> translators;

        private readonly string[] pageSeparator;

        public TextTranslator(LocalizationTextConfig config)
        {
            var pages = config.spreadsheet.pages;
            var count = pages.Length;

            this.translators = new Dictionary<string, ITranslator<string>>(count);
            for (var i = 0; i < count; i++)
            {
                var page = pages[i];
                this.translators[page.name] = new LocalizationModule.TextTranslator(page.entities);
            }

            this.pageSeparator = new[]
            {
                config.pageSeparator
            };
        }

        public string GetTranslation(string key, SystemLanguage language)
        {
            if (!TextKeyParser.TryParse(key, this.pageSeparator, out var pageName, out var entityKey))
            {
                Debug.LogWarning($"Can not parse key {key}!");
                return key;
            }

            if (!this.translators.TryGetValue(pageName, out var translator))
            {
                Debug.LogWarning($"Translator is not found: {entityKey}!");
                return key;
            }

            return translator.GetTranslation(entityKey, language);
        }
    }
}