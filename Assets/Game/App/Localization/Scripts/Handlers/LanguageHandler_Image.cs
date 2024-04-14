using System;
using UnityEngine;
using UnityEngine.UI;

namespace LocalizationModule
{
    [Serializable]
    public sealed class LanguageHandler_Image : ILanguageHandler
    {
        [SerializeField]
        private Image image;

        [SerializeField]
        private LocalizedSprite[] sprites = new LocalizedSprite[0];
        
        public void UpdateLanguage(SystemLanguage language)
        {
            if (this.sprites.FindSprite(language, out var sprite))
            {
                this.image.sprite = sprite;                
            }
        }
    }
}