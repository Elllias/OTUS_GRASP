using System.Linq;
using Homeworks.PresentationModel.Scripts.Fabrics;
using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class UserPopupObserver
    {
        private const string CHARACTERISTIC_SEPARATOR = ":";
        private const string XP_TEXT_FORMAT = "XP: {0}/{1}";
        private const string LEVEL_TEXT = "Level: ";

        private readonly UserPopupView _userPopupView;
        private readonly UserInfo _userInfo;
        private readonly CharacterInfo _characterInfo;
        private readonly PlayerLevel _playerLevel;

        private CharacteristicViewFabric _characteristicViewFabric;

        public UserPopupObserver(UserPopupView userPopupView, UserInfo userInfo, CharacterInfo characterInfo,
            PlayerLevel playerLevel)
        {
            _userPopupView = userPopupView;
            _userInfo = userInfo;
            _characterInfo = characterInfo;
            _playerLevel = playerLevel;

            _userPopupView.CloseButtonPressed += OnCloseButtonPressed;
            _userPopupView.LevelUpButtonPressed += OnLevelUpButtonPressed;

            _characteristicViewFabric = GetCharacteristicViewFabric();

            InitializePopup();
            InitializeListeners();
        }

        ~UserPopupObserver()
        {
            _userPopupView.CloseButtonPressed -= OnCloseButtonPressed;
            _userPopupView.LevelUpButtonPressed -= OnLevelUpButtonPressed;

            DeinitializeListeners();
        }

        private void InitializePopup()
        {
            SetName(_userInfo.Name);
            SetDescription(_userInfo.Description);
            SetIcon(_userInfo.Icon);

            SetLevel(_playerLevel.CurrentLevel);
            SetExp(_playerLevel.CurrentExperience);

            AddCharacteristics(_characterInfo.GetStats());
        }

        private void InitializeListeners()
        {
            _userInfo.OnNameChanged += SetName;
            _userInfo.OnDescriptionChanged += SetDescription;
            _userInfo.OnIconChanged += SetIcon;

            _playerLevel.OnExperienceChanged += SetExp;
            _playerLevel.OnLevelUp += SetLevel;

            _characterInfo.OnStatAdded += AddCharacteristic;
            _characterInfo.OnStatRemoved += RemoveCharacteristic;
        }

        private void DeinitializeListeners()
        {
            _userInfo.OnNameChanged -= SetName;
            _userInfo.OnDescriptionChanged -= SetDescription;
            _userInfo.OnIconChanged -= SetIcon;

            _playerLevel.OnExperienceChanged -= SetExp;
            _playerLevel.OnLevelUp -= SetLevel;

            _characterInfo.OnStatAdded -= AddCharacteristic;
            _characterInfo.OnStatRemoved -= RemoveCharacteristic;
        }

        private void OnCloseButtonPressed()
        {
            _userPopupView.Hide();
        }

        private void OnLevelUpButtonPressed()
        {
            _playerLevel.LevelUp();
        }

        private void SetExp(int expValue)
        {
            var expText = string.Format(XP_TEXT_FORMAT, expValue, _playerLevel.RequiredExperience);
            _userPopupView.SetExpText(expText);
            _userPopupView.SetExpSliderValue(expValue / (float)_playerLevel.RequiredExperience);

            if (_playerLevel.CanLevelUp())
                _userPopupView.ActivateLevelButton();
            else
                _userPopupView.DeactivateLevelButton();
        }

        private void SetName(string idText)
        {
            _userPopupView.SetName(idText);
        }

        private void SetDescription(string descriptionText)
        {
            _userPopupView.SetDescription(descriptionText);
        }

        private void SetIcon(Sprite sprite)
        {
            _userPopupView.SetIcon(sprite);
        }

        private void SetLevel(int level)
        {
            _userPopupView.SetLevelText(LEVEL_TEXT + level);

            SetExp(0);
        }

        private void AddCharacteristic(CharacterStat characterStat)
        {
            var characteristicView = _characteristicViewFabric.SpawnCharacteristicView();

            _userPopupView.AddCharacteristic(characteristicView);

            characteristicView.SetName(characterStat.Name + CHARACTERISTIC_SEPARATOR);
            characteristicView.SetValue(characterStat.Value);

            characterStat.OnValueChanged += characteristicView.SetValue;

            _userPopupView.RebuildCharacteristicsView();
        }

        private void AddCharacteristics(CharacterStat[] characterStats)
        {
            foreach (var characterStat in characterStats)
            {
                AddCharacteristic(characterStat);
            }

            _userPopupView.RebuildCharacteristicsView();
        }

        private void RemoveCharacteristic(CharacterStat characteristicStat)
        {
            var characteristicViews = _userPopupView.GetCharacteristics();

            var removedCharacteristic =
                characteristicViews.FirstOrDefault(
                    view => view.GetName() == characteristicStat.Name + CHARACTERISTIC_SEPARATOR);

            if (removedCharacteristic == null)
                return;

            _userPopupView.RemoveCharacteristic(removedCharacteristic);

            characteristicStat.OnValueChanged -= removedCharacteristic.SetValue;

            Object.Destroy(removedCharacteristic.gameObject);
        }

        private CharacteristicViewFabric GetCharacteristicViewFabric()
        {
            var prefab = _userPopupView.GetCharacteristicPrefab();
            var parent = _userPopupView.GetCharacteristicParent();

            return new CharacteristicViewFabric(parent, prefab);
        }
    }
}