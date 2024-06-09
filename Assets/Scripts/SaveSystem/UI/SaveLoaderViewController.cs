using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using UnityEditor.VersionControl;

namespace SaveSystem.UI
{
    public class SaveLoaderViewController
    {
        private readonly SaveLoaderView _view;
        private readonly GameRepository _repository;
        private readonly ISaveLoader[] _saveLoaders;

        public SaveLoaderViewController(SaveLoaderView view, GameRepository repository, params ISaveLoader[] saveLoaders)
        {
            _view = view;
            _repository = repository;
            _saveLoaders = saveLoaders;

            _view.GetLoadButton().onClick.AddListener(OnLoadButtonClick);
            _view.GetSaveButton().onClick.AddListener(OnSaveButtonClick);
        }

        ~SaveLoaderViewController()
        {
            _view.GetLoadButton().onClick.RemoveListener(OnLoadButtonClick);
            _view.GetSaveButton().onClick.RemoveListener(OnSaveButtonClick);
        }

        private void OnSaveButtonClick()
        {
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Save(_repository);
            }
            
            _repository.SaveState();
        }

        private void OnLoadButtonClick()
        {
            _repository.LoadState();
            
            foreach (var saveLoader in _saveLoaders)
            {
                saveLoader.Load(_repository);
            }
        }
    }
}