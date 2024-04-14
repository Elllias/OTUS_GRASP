using Game.App;
using Game.GameEngine.Mechanics;
using JetBrains.Annotations;

namespace Game.Gameplay.Conveyors
{
    [UsedImplicitly]
    public sealed class ConveyorsMediator : GameMediator<ConveyorData[], ConveyorsService>
    {
        protected override void SetupFromData(ConveyorsService service, ConveyorData[] dataSet)
        {
            for (int i = 0, count = dataSet.Length; i < count; i++)
            {
                var data = dataSet[i];
                var conveyor = service.FindConveyor(data.id);

                conveyor
                    .Get<IComponent_LoadZone>()
                    .SetupAmount(data.inputAmount);
                conveyor
                    .Get<IComponent_UnloadZone>()
                    .SetupAmount(data.outputAmount);
            }
        }

        protected override void SetupByDefault(ConveyorsService service)
        {
            //Do nothing...
        }

        protected override ConveyorData[] ConvertToData(ConveyorsService service)
        {
            var conveyors = service.GetAllConveyors();
            var count = conveyors.Length;
            var dataArray = new ConveyorData[count];

            for (var i = 0; i < count; i++)
            {
                var conveyor = conveyors[i];
                var data = new ConveyorData
                {
                    id = conveyor.Get<IComponent_GetId>().Id,
                    inputAmount = conveyor.Get<IComponent_LoadZone>().CurrentAmount,
                    outputAmount = conveyor.Get<IComponent_UnloadZone>().CurrentAmount
                };
                dataArray[i] = data;
            }

            return dataArray;
        }
    }
}