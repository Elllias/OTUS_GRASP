using Sample.Inventory;
using Zenject;

namespace Inventory
{
    public sealed class InventoryInstaller : Installer<InventoryInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IInventory>()
                .To<InventoryDummy>()
                .AsSingle()
                .NonLazy();
        }
    }
}