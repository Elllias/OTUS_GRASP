using Game.App;
using JetBrains.Annotations;

namespace Game.Gameplay.Player
{
    [UsedImplicitly]
    public class MoneyMediator : GameMediator<MoneyData, MoneyStorage>
    {
        protected override void SetupFromData(MoneyStorage service, MoneyData data)
        {
            service.SetupMoney(data.money);
        }

        protected override void SetupByDefault(MoneyStorage service)
        {
            var config = MoneyStorageConfig.LoadAsset();
            service.SetupMoney(config.InitialMoney);
        }

        protected override MoneyData ConvertToData(MoneyStorage service)
        {
            return new MoneyData
            {
                money = service.Money
            };
        }
    }
}