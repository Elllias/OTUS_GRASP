using GameEngine;
using UnityEngine;

//TODO: Удалить этот класс!
//Развернуть архитектуру на Zenject/VContainer/Custom
public sealed class EntryPoint : MonoBehaviour
{
    [SerializeField]
    private UnitManager unitManager;

    [SerializeField]
    private ResourceService resourceService;
    
    private void Start()
    {
        this.unitManager.SetupUnits(FindObjectsOfType<Unit>());
        this.resourceService.SetResources(FindObjectsOfType<Resource>());
    }
}