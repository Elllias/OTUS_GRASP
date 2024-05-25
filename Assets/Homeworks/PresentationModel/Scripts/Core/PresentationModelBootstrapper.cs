using Homeworks.PresentationModel.Scripts.UI.Controller;
using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;
using UnityEngine;
using CharacterInfo = Lessons.Architecture.PM.CharacterInfo;

namespace Homeworks.PresentationModel.Scripts.Core
{
    /// <summary>
    /// Представление модели. По идее, в проекте этого класса бы не было. Нужен только для теста.
    /// </summary>
    public class PresentationModelBootstrapper : MonoBehaviour
    {
        [SerializeField] private UserPopupView _userPopupView;
        [SerializeField] private NameView _nameView;
        [SerializeField] private DescriptionView _descriptionView;
        [SerializeField] private ExpView _expView;
        [SerializeField] private CharacteristicContainerView _characteristicContainerView;
        [SerializeField] private ButtonView _levelUpButtonView;
        [SerializeField] private ButtonView _closeButtonView;
        
        [SerializeField] private CharacterInfo _characterInfo;
        [SerializeField] private PlayerLevel _playerLevel;
        [SerializeField] private UserInfo _userInfo;
        
        private DescriptionViewController _descriptionViewController;
        private NameViewController _nameViewController;
        private ExpViewController _expViewController;
        private CharacteristicContainerViewController _characteristicContainerViewController;
        private LevelUpButtonViewController _levelUpButtonViewController;
        private CloseButtonViewController _closeButtonViewController;
        
        private void Start()
        {
            _descriptionViewController = new DescriptionViewController(_descriptionView, _userInfo, _playerLevel);
            _nameViewController = new NameViewController(_nameView, _userInfo);
            _expViewController = new ExpViewController(_expView, _playerLevel);
            _characteristicContainerViewController = new CharacteristicContainerViewController(_characteristicContainerView, _characterInfo);
            _levelUpButtonViewController = new LevelUpButtonViewController(_levelUpButtonView, _playerLevel);
            _closeButtonViewController = new CloseButtonViewController(_closeButtonView, _userPopupView);
        }
    }
}