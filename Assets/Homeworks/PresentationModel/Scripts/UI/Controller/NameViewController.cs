using Homeworks.PresentationModel.Scripts.UI.View;
using Lessons.Architecture.PM;

namespace Homeworks.PresentationModel.Scripts.UI.Controller
{
    public class NameViewController
    {
        private readonly NameView _view;
        private readonly UserInfo _userInfo;

        public NameViewController(NameView view, UserInfo userInfo)
        {
            _view = view;
            _userInfo = userInfo;

            SetName(_userInfo.Name);
            _userInfo.OnNameChanged += SetName;
        }

        ~NameViewController()
        {
            _userInfo.OnNameChanged -= SetName;
        }

        private void SetName(string name)
        {
            _view.SetNameText(name);
        }
    }
}