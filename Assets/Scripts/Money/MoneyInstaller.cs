using TechTree;
using Zenject;

namespace Money
{
    public sealed class MoneyInstaller : Installer<MoneyInstaller>
    {
        private const int INITIAL_MONEY = 10000;

        public override void InstallBindings()
        {
            Container
                .Bind<IMoneyStorage>()
                .To<MoneyStorage>()
                .AsSingle()
                .WithArguments(INITIAL_MONEY)
                .NonLazy();
        }
    }
}