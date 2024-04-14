using Game.App;
using JetBrains.Annotations;
using Services;

namespace Game.Meta
{
    [UsedImplicitly]
    public sealed class BoostersMediator : GameMediator<BoosterData[], BoostersManager>
    {
        [ServiceInject]
        private BoostersAssetSupplier assetSupplier;

        protected override void SetupFromData(BoostersManager service, BoosterData[] dataSet)
        {
            for (int i = 0, count = dataSet.Length; i < count; i++)
            {
                var data = dataSet[i];
                var config = this.assetSupplier.GetBooster(data.id);
                var booster = service.SetupBooster(config);
                booster.RemainingTime = data.remainingTime;
            }
        }

        protected override void SetupByDefault(BoostersManager service)
        {
            //Do nothing...
        }

        protected override BoosterData[] ConvertToData(BoostersManager service)
        {
            var boosters = service.GetActiveBoosters();
            var count = boosters.Length;
            var boostersData = new BoosterData[count];

            for (var i = 0; i < count; i++)
            {
                var booster = boosters[i];
                var data = new BoosterData
                {
                    id = booster.Id,
                    remainingTime = booster.RemainingTime
                };

                boostersData[i] = data;
            }

            return boostersData;
        }
    }
}