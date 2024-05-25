using Homeworks.PresentationModel.Scripts.UI.View;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class CloseButtonViewController
    {
        private readonly ButtonView _view;
        private readonly UserPopupView _popupView;

        public CloseButtonViewController(ButtonView view, UserPopupView popupView)
        {
            _view = view;
            _popupView = popupView;
            
            _view.GetButton().onClick.AddListener(OnCloseButtonClicked);
        }

        ~CloseButtonViewController()
        {
            _view.GetButton().onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked()
        {
            _popupView.Hide();
        }
    }
}