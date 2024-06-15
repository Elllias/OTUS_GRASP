using Core.Controllers;
using Core.Data;
using Core.Handlers;
using Core.Pipelines;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Scopes
{
    public class SceneLifetimeScope : LifetimeScope
    {
        [SerializeField] private UIService _uiService;
        [SerializeField] private HeroContainer _heroContainer;
        
        private IContainerBuilder _builder;
        
        protected override void Configure(IContainerBuilder builder)
        {
            _builder = builder;
            
            RegisterEventBusDependencies();
            RegisterPipelineDependencies();
            
            builder.RegisterEntryPoint<ApplicationBootstrapper>();
        }

        private void RegisterPipelineDependencies()
        {
            _builder.Register<GamePipeline>(Lifetime.Singleton);
            _builder.RegisterEntryPoint<GamePipelineInstaller>();
            
            var redHeroesController = new RedHeroesController(_uiService.GetRedPlayer(), _heroContainer);
            var blueHeroesController = new BlueHeroesController(_uiService.GetBluePlayer(), _heroContainer);

            _builder.RegisterInstance(redHeroesController);
            _builder.RegisterInstance(blueHeroesController);
            _builder.RegisterInstance(_heroContainer);
        }

        private void RegisterEventBusDependencies()
        {
            _builder.Register<EventBus>(Lifetime.Singleton);
            _builder.RegisterEntryPoint<AttackEventHandler>();
        }
    }
}
