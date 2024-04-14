using System.Linq;
using TMPro;
using UnityEngine;

namespace Game.App
{
    public sealed class QualitySettingsWidget : MonoBehaviour
    {
        [SerializeField]
        private TMP_Dropdown dropdown;

        private void Awake()
        {
            this.InitDropdown();
        }

        private void OnEnable()
        {
            this.dropdown.onValueChanged.AddListener(this.OnLevelChanged);
        }

        private void OnDisable()
        {
            this.dropdown.onValueChanged.RemoveListener(this.OnLevelChanged);
        }

        private void OnLevelChanged(int level)
        {
            QualitySettingsManager.SetLevel(level);
        }

        private void InitDropdown()
        {
            var options = QualitySettingsManager
                .GetLevelNames()
                .Select(it => it.ToUpper())
                .ToList();
            
            this.dropdown.ClearOptions();
            this.dropdown.AddOptions(options);
            this.dropdown.value = QualitySettingsManager.GetLevel();
        }
    }
}