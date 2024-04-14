using System.Collections.Generic;
using Game.App;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.UI
{
    public sealed class LanguageSettingsWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown dropdown;

        private void Awake()
        {
            this.InitDropdown();
        }

        private void OnEnable()
        {
            this.dropdown.onValueChanged.AddListener(this.OnLanguageChanged);
        }

        private void OnDisable()
        {
            this.dropdown.onValueChanged.RemoveListener(this.OnLanguageChanged);
        }

        private void OnLanguageChanged(int languageIndex)
        {
            LanguageManager.SetCurrentLanguage(languageIndex); 
        }
        
        private void InitDropdown()
        {
            var languages = LanguageManager.GetLanguages();
            var currentLanguage = LanguageManager.CurrentLanguage;
            var count = languages.Length;

            var options = new List<string>(count);
            var targetIndex = 0;

            for (var i = 0; i < count; i++)
            {
                LanguageInfo info = languages[i];
                options.Add(info.title.ToUpper());

                if (info.language == currentLanguage)
                {
                    targetIndex = i;
                }
            }

            this.dropdown.ClearOptions();
            this.dropdown.AddOptions(options);
            this.dropdown.value = targetIndex;
        }
    }
}