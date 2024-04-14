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
        [SerializeField] private CharacterInfo _characterInfo;
        [SerializeField] private PlayerLevel _playerLevel;
        [SerializeField] private UserInfo _userInfo;

        private UserPopupObserver _userPopupObserver;
        
        private void Start()
        {
            _userPopupObserver = new UserPopupObserver(_userPopupView, _userInfo, _characterInfo, _playerLevel);
        }
    }
}