using Core;
using Interface;
using LevelUtils;
using UI.Base;
using UI.GameFinishPanel;
using UI.GameStartPanel;
using UI.PauseTogglePanel;
using UnityEngine.PlayerLoop;
using VContainer;
using VContainer.Unity;

namespace Lifetimes
{
    public class SceneLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<InputHandler>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<GameManager>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.RegisterComponentInHierarchy<LevelBackgroundController>().As<ITickable>();
        }
    }
}
