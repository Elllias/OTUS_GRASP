using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;
using UnityEngine;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class DescriptionViewController
    {
        private const string LEVEL_TEXT = "Level: ";
        
        private readonly DescriptionView _view;
        private readonly UserInfo _userInfo;
        private readonly PlayerLevel _playerLevel;

        public DescriptionViewController(DescriptionView view, UserInfo userInfo, PlayerLevel playerLevel)
        {
            _view = view;
            _userInfo = userInfo;
            _playerLevel = playerLevel;

            InitializeView();
            InitializeListeners();
        }

        ~DescriptionViewController()
        {
            DeinitializeListeners();
        }

        private void InitializeView()
        {
            SetDescription(_userInfo.Description);
            SetIcon(_userInfo.Icon);
            SetLevel(_playerLevel.CurrentLevel);
        }

        private void InitializeListeners()
        {
            _userInfo.OnDescriptionChanged += SetDescription;
            _userInfo.OnIconChanged += SetIcon;
            _playerLevel.OnLevelUp += SetLevel;
        }

        private void DeinitializeListeners()
        {
            _userInfo.OnDescriptionChanged -= SetDescription;
            _userInfo.OnIconChanged -= SetIcon;
            _playerLevel.OnLevelUp -= SetLevel;
        }
        
        private void SetDescription(string descriptionText)
        {
            _view.SetDescription(descriptionText);
        }

        private void SetIcon(Sprite sprite)
        {
            _view.SetIcon(sprite);
        }

        private void SetLevel(int level)
        {
            _view.SetLevelText(LEVEL_TEXT + level);
        }
    }
}