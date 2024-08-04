using Inventory;
using Money;
using Weapons;
using Zenject;

namespace Sample
{
    public sealed class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            MoneyInstaller.Install(this.Container);
            BuildingInstaller.Install(this.Container);
            InventoryInstaller.Install(this.Container);
        }
    }
}