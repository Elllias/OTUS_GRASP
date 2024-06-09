using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using Lessons.Architecture.DI;
using SaveSystem;
using SaveSystem.Systems;
using SaveSystem.UI;
using SaveSystem.Utils;
using UnityEngine;

public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField] private UnitManager _unitManager;
    [SerializeField] private ResourceService _resourceService;
    [SerializeField] private PlayerResources _playerResources;

    [SerializeField] private UnitsConfig _unitsConfig;

    [SerializeField] private ButtonView _saveView;
    [SerializeField] private ButtonView _loadView;

    private LoadViewController _loadViewController;
    private SaveViewController _saveViewController;


    private void Start()
    {
        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
        _resourceService.SetResources(FindObjectsOfType<Resource>());

        BindServices();

        var playerSaveLoader = new PlayerSaveLoader();
        var resourceSaveLoader = new ResourceSaveLoader();
        var unitsSaveLoader = new UnitsSaveLoader();

        var saveService = new FileSaveService();
        var gameRepository = new GameRepository(saveService);

        _loadViewController =
            new LoadViewController(
                _loadView,
                gameRepository,
                playerSaveLoader,
                resourceSaveLoader,
                unitsSaveLoader);
        
        _saveViewController =
            new SaveViewController(
                _saveView,
                gameRepository,
                playerSaveLoader,
                resourceSaveLoader,
                unitsSaveLoader);
    }

    private void BindServices()
    {
        ServiceLocator.BindService(typeof(UnitManager), _unitManager);
        ServiceLocator.BindService(typeof(ResourceService), _resourceService);
        ServiceLocator.BindService(typeof(PlayerResources), _playerResources);
        ServiceLocator.BindService(typeof(UnitsConfig), _unitsConfig);
    }
}