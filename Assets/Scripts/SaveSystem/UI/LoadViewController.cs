using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using SaveSystem.Interfaces;
using SaveSystem.Systems;
using UnityEditor.VersionControl;

namespace SaveSystem.UI
{
    public class LoadViewController
    {
        private readonly ButtonView _view;
        private readonly GameRepository _repository;
        private readonly ISaveLoader[] _saveLoaders;

        public LoadViewController(ButtonView view, GameRepository repository, params ISaveLoader[] saveLoaders)
        {
            _view = view;
            _repository = repository;
            _saveLoaders = saveLoaders;

            _view.GetButton().onClick.AddListener(OnLoadButtonClick);
        }

        ~LoadViewController()
        {
            _view.GetButton().onClick.RemoveListener(OnLoadButtonClick);
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