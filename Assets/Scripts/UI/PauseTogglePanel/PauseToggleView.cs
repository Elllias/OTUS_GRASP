using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.PauseTogglePanel
{
    public class PauseToggleView : MonoBehaviour
    {
        public event Action ToggleButtonClicked;
        
        [SerializeField] private Button _toggleButton;
        [SerializeField] private TMP_Text _toggleButtonText;
        
        private void Awake()
        {
            _toggleButton.onClick.AddListener(OnToggleButtonClicked);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void SetText(string text)
        {
            _toggleButtonText.text = text;
        }
        
        private void OnToggleButtonClicked()
        {
            ToggleButtonClicked?.Invoke();
        }
    }
}