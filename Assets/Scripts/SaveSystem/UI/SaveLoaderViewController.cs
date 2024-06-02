using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using SaveSystem.Interfaces;

namespace SaveSystem.UI
{
    public class SaveLoaderViewController
    {
        private readonly SaveLoaderView _view;

        private readonly ResourceService _resourceService;
        private readonly UnitManager _unitManager;
        private readonly PlayerResources _playerResources;
        private readonly ISaveLoader<UnitManager> _unitsSaveLoader;
        private readonly ISaveLoader<ResourceService> _resourceSaveLoader;
        private readonly ISaveLoader<PlayerResources> _playerSaveLoader;

        public SaveLoaderViewController(
            SaveLoaderView view,
            ResourceService resourceService,
            UnitManager unitManager,
            UnitsConfig unitsConfig,
            PlayerResources playerResources)
        {
            _view = view;

            _resourceService = resourceService;
            _unitManager = unitManager;
            _playerResources = playerResources;
            _resourceSaveLoader = new ResourceSaveLoader();
            _playerSaveLoader = new PlayerSaveLoader();
            _unitsSaveLoader = new UnitsSaveLoader(unitsConfig);

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
            _resourceSaveLoader.Save(_resourceService);
            _unitsSaveLoader.Save(_unitManager);
            _playerSaveLoader.Save(_playerResources);
        }

        private void OnLoadButtonClick()
        {
            _resourceSaveLoader.Load(_resourceService);
            _unitsSaveLoader.Load(_unitManager);
            _playerSaveLoader.Load(_playerResources);
        }
    }
}