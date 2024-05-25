using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;
using UnityEngine.UI;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class LevelUpButtonViewController
    {
        private readonly Button _button;
        private readonly PlayerLevel _playerLevel;

        public LevelUpButtonViewController(ButtonView view, PlayerLevel playerLevel)
        {
            _button = view.GetButton();
            _playerLevel = playerLevel;

            InitializeButton();
            
            _playerLevel.OnExperienceChanged += OnExperienceChanged;
            _button.onClick.AddListener(OnLevelUpButtonClicked);
        }
        
        ~LevelUpButtonViewController()
        {
            _playerLevel.OnExperienceChanged -= OnExperienceChanged;
            _button.onClick.RemoveListener(OnLevelUpButtonClicked);
        }
        
        private void InitializeButton()
        {
            _button.interactable = _playerLevel.CanLevelUp();
        }
        
        private void OnExperienceChanged(int obj)
        {
            InitializeButton();
        }
        
        private void OnLevelUpButtonClicked()
        {
            _playerLevel.LevelUp();
            InitializeButton();
        }
    }
}