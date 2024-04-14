using UnityEngine;

namespace Lessons.Architecture.DI
{
    public sealed class GameContext : MonoBehaviour
    {
        [SerializeField]
        private GameManager gameManager;
        
        [SerializeField]
        private ServiceLocator serviceLocator;

        [SerializeField]
        private MonoBehaviour[] modules;

        private void Awake()
        {
            foreach (var module in this.modules)
            {
                if (module is IGameListenerProvider listenerProvider)
                {
                    this.gameManager.AddListeners(listenerProvider.ProvideListeners());
                }
                
                if (module is IServiceProvider serviceProvider)
                {
                    var services = serviceProvider.ProvideServices();
                    foreach (var (type, service)  in services)
                    {
                        this.serviceLocator.BindService(type, service);
                    }
                }
            }  
        }

        private void Start()
        {
            foreach (var module in this.modules)
            {
                if (module is IInjectProvider injectProvider)
                {
                    injectProvider.Inject(this.serviceLocator);
                }
            }
            
            this.InjectGameObjectsOnScene();
        }

        private void InjectGameObjectsOnScene()
        {
            GameObject[] gameObjects = this.gameObject.scene.GetRootGameObjects();

            foreach (var go in gameObjects)
            {
                this.Inject(go.transform);
            }
        }

        private void Inject(Transform targetTransform)
        {
            var targets = targetTransform.GetComponents<MonoBehaviour>();
            foreach (var target in targets)
            {
                DependencyInjector.Inject(target, this.serviceLocator);
            }

            foreach (Transform child in targetTransform)
            {
                this.Inject(child);
            }
        }
    }
}