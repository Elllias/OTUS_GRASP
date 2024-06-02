using GameEngine;
using GameEngine.ScriptableObjects;
using GameEngine.Systems;
using SaveSystem.UI;
using UnityEngine;

public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField] private UnitManager _unitManager;
    [SerializeField] private ResourceService _resourceService;
    [SerializeField] private PlayerResources _playerResources;

    [SerializeField] private UnitsConfig _unitsConfig;
    
    [SerializeField] private SaveLoaderView _saveLoaderView;
    
    private SaveLoaderViewController _saveLoaderViewController;
    
    private void Start()
    {
        _unitManager.SetupUnits(FindObjectsOfType<Unit>());
        _resourceService.SetResources(FindObjectsOfType<Resource>());
        
        _saveLoaderViewController = 
            new SaveLoaderViewController(
            _saveLoaderView,
            _resourceService,
            _unitManager,
            _unitsConfig,
            _playerResources);
    }
}