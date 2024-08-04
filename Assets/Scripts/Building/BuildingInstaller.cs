using Zenject;

namespace Weapons
{
    public sealed class BuildingInstaller : Installer<BuildingInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IBuildingSystem>()
                .To<BuildingDummy>()
                .AsSingle()
                .NonLazy();
        }
    }
}