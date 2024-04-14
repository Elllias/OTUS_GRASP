#if UNITY_EDITOR
using JetBrains.Annotations;

namespace Game.Gameplay.Player
{
    [UsedImplicitly]
    public sealed class DebugMoneyMediator : MoneyMediator
    {
        protected override void SetupByDefault(MoneyStorage service)
        {
            var config = DebugMoneyConfig.LoadAsset();
            if (config.debugMode)
            {
                var data = new MoneyData
                {
                    money = config.money
                };
                base.SetupFromData(service, data);
            }
            else
            {
                base.SetupByDefault(service);
            }
        }

        protected override void SetupFromData(MoneyStorage service, MoneyData data)
        {
            var config = DebugMoneyConfig.LoadAsset();
            if (config.debugMode)
            {
                data.money = config.money;
            }

            base.SetupFromData(service, data);
        }
    }
}
#endif