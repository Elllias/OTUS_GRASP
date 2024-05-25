using System;
using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class ExpViewController
    {
        private const string XP_TEXT_FORMAT = "XP: {0}/{1}";
        
        private readonly ExpView _view;
        private readonly PlayerLevel _playerLevel;

        public ExpViewController(ExpView view, PlayerLevel playerLevel)
        {
            _view = view;
            _playerLevel = playerLevel;

            SetExp(_playerLevel.CurrentExperience);
            
            _playerLevel.OnExperienceChanged += SetExp;
            _playerLevel.OnLevelUp += ResetExp;
        }

        ~ExpViewController()
        {
            _playerLevel.OnExperienceChanged -= SetExp;
            _playerLevel.OnLevelUp -= ResetExp;
        }

        private void ResetExp(int _)
        {
            var expText = string.Format(XP_TEXT_FORMAT, 0, _playerLevel.RequiredExperience);
            _view.SetText(expText);
            _view.SetSliderValue(0);
        }

        private void SetExp(int expValue)
        {
            var expText = string.Format(XP_TEXT_FORMAT, expValue, _playerLevel.RequiredExperience);
            _view.SetText(expText);
            _view.SetSliderValue(expValue / (float)_playerLevel.RequiredExperience);

            /*if (_playerLevel.CanLevelUp())
                _userPopupView.ActivateLevelButton();
            else
                _userPopupView.DeactivateLevelButton();*/
        }
    }
}