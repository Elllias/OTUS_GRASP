using System;
using System.Collections.Generic;
using Lessons.Architecture.PM;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.View
{
    public class UserPopupView : MonoBehaviour
    {
        public event Action CloseButtonPressed;
        public event Action LevelUpButtonPressed;
    
        [SerializeField] private Button _closeButton;
        [SerializeField] private Button _levelUpButton;

        [SerializeField] private TMP_Text _name;
        [SerializeField] private UserDescriptionView _descriptionView;
        [SerializeField] private UserExpView _expView;
        [SerializeField] private UserCharacteristicsView _characteristicsView;

        private void Awake()
        {
            _closeButton.onClick.AddListener(OnCloseButtonPressed);
            _levelUpButton.onClick.AddListener(OnLevelUpButtonPressed);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ActivateLevelButton()
        {
            _levelUpButton.interactable = true;
        }
        
        public void DeactivateLevelButton()
        {
            _levelUpButton.interactable = false;
        }

        public void SetName(string userIdText)
        {
            _name.text = userIdText;
        }
    
        public void SetDescription(string description)
        {
            _descriptionView.SetDescription(description);
        }

        public void SetIcon(Sprite sprite)
        {
            _descriptionView.SetIcon(sprite);
        }

        public void SetLevelText(string levelText)
        {
            _descriptionView.SetLevelText(levelText);
        }

        public void SetExpSliderValue(float exp)
        {
            _expView.SetSliderValue(exp);
        }

        public void SetExpText(string text)
        {
            _expView.SetText(text);
        }

        public void AddCharacteristic(CharacteristicView characteristic)
        {
            _characteristicsView.AddCharacteristic(characteristic);
        }

        public void RemoveCharacteristic(CharacteristicView characteristic)
        {
            _characteristicsView.RemoveCharacteristic(characteristic);
        }

        public CharacteristicView GetCharacteristicPrefab()
        {
            return _characteristicsView.GetPrefab();
        }

        public Transform GetCharacteristicParent()
        {
            return _characteristicsView.GetCharacteristicParent();
        }
        
        public List<CharacteristicView> GetCharacteristics()
        {
            return _characteristicsView.GetCharacteristics();
        }

        public void RebuildCharacteristicsView()
        {
            _characteristicsView.RebuildLayout();
        }

        private void OnCloseButtonPressed()
        {
            CloseButtonPressed?.Invoke();
        }
    
        private void OnLevelUpButtonPressed()
        {
            LevelUpButtonPressed?.Invoke();
        }
    }
}
