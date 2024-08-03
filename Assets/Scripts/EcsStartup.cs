using APIs;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.Entities;
using Systems;
using UnityEngine;
using Views;

internal sealed class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private EcsWorld _events;
    private IEcsSystems _systems;
    private EntityManager _entityManager;

    private void Awake()
    {
        _entityManager = new EntityManager();
        _world = new EcsWorld();
        _events = new EcsWorld();
        _systems = new EcsSystems(_world);
        _systems.AddWorld(_events, EcsWorldsApi.EVENTS);
        _systems
            .Add(new MovementSystem())
            .Add(new FireRequestSystem())
            .Add(new SpawnBulletRequestSystem())
            .Add(new UnitDetectionSystem())
            .Add(new LifeTimeSystem())
            
            // View
            .Add(new TransformViewSystem())
#if UNITY_EDITOR
            .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
            .Add(new DestroyRequestSystem())
            ;
    }
    
    private void Start()
    {
        _entityManager.Initialize(_world);
        _systems?.Inject(_entityManager);
        _systems?.Init();
    }

    private void Update()
    {
        _systems?.Run();
    }

    private void OnDestroy()
    {
        if (_systems != null)
        {
            _systems.Destroy();
            _systems = null;
        }

        if (_world != null)
        {
            _world.Destroy();
            _world = null;
        }
    }
}