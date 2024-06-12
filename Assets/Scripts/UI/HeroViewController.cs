using System;

namespace UI
{
    public class HeroViewController
    {
        public event Action Clicked;
        
        private readonly HeroView _view;

        public HeroViewController(HeroView view)
        {
            _view = view;

            _view.OnClicked += OnClicked;
        }

        ~HeroViewController()
        {
            _view.OnClicked -= OnClicked;
        }

        private void OnClicked()
        {
            Clicked?.Invoke();
        }
    }
}