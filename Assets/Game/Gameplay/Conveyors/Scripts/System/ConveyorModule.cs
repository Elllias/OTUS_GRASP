using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Conveyors
{
    public sealed class ConveyorModule : GameModule
    {
        [GameService]
        [ReadOnly, ShowInInspector]
        private ConveyorsService conveyorsService = new();

        [GameElement]
        private ConveyorsEnableController enableController = new();
    }
}