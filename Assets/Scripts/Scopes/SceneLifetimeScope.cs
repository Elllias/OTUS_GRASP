using Core;
using Core.Pipelines;
using Handlers;
using UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Scopes
{
    public class SceneLifetimeScope : LifetimeScope
    {
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
            _builder.Register<MainPipeline>(Lifetime.Singleton);
            _builder.RegisterEntryPoint<MainPipelineInstaller>();
        }

        private void RegisterEventBusDependencies()
        {
            _builder.Register<EventBus>(Lifetime.Singleton);
            _builder.Register<AttackEventHandler>(Lifetime.Singleton);
        }
    }
}
