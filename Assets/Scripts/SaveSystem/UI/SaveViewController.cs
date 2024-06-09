using SaveSystem.Interfaces;
using SaveSystem.Systems;

namespace SaveSystem.UI
{
    public class SaveViewController
    {
        private readonly ButtonView _view;
        private readonly GameRepository _repository;
        private readonly ISaveLoader[] _saveLoaders;

        public SaveViewController(ButtonView view, GameRepository repository, params ISaveLoader[] saveLoaders)
        {
            _view = view;
            _repository = repository;
            _saveLoaders = saveLoaders;

            _view.GetButton().onClick.AddListener(OnSaveButtonClick);
        }

        ~SaveViewController()
        {
            _view.GetButton().onClick.RemoveListener(OnSaveButtonClick);
        }
        
        private void OnSaveButtonClick()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Save(_repository);
            }
            
            _repository.SaveState();
        }
    }
}