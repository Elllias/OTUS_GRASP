using Game.App;
using Game.GameEngine.GameResources;
using JetBrains.Annotations;

namespace Game.Gameplay.Player
{
    [UsedImplicitly]
    public sealed class ResourceMediator : GameMediator<ResourceData[], ResourceStorage>
    {
        protected override void SetupFromData(ResourceStorage service, ResourceData[] data)
        {
            service.Setup(data);
        }

        protected override void SetupByDefault(ResourceStorage service)
        {
            var config = ResourceStorageConfig.LoadAsset();
            service.Setup(config.InitialResources);
        }

        protected override ResourceData[] ConvertToData(ResourceStorage service)
        {
            return service.GetAllResources();
        }
    }
}