using GameSystem;
using JetBrains.Annotations;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Player
{
    public sealed class PlayerMechanicsModule : GameModule
    {
        [Header("Harvest Resource")]
        [GameElement]
        [SerializeField]
        private HarvestResourceObserver harvestObserver = new();
        
        [Header("Enemies")]
        [GameElement]
        [SerializeField]
        private KillEnemyObserver killEnemyObserver;
        
        [Header("Conveyor")]
        [GameService]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitInteractor conveyorVisitInteractor = new();

        [GameElement]
        private readonly ConveyorVisitUnloadZoneObserver conveyorUnloadZoneObserver = new();

        [GameElement]
        private readonly ConveyorVisitInputZoneObserver conveyorLoadZoneObserver = new();
        
        [Header("Vendor")]
        [GameService]
        [SerializeField]
        private VendorInteractor vendorInteractor = new();
        
        [Header("World Place")]
        [UsedImplicitly]
        [SerializeField]
        private WorldPlacePopupConfig worldPlacePopupConfig;

        [GameService]
        [ShowInInspector, ReadOnly]
        private readonly WorldPlaceVisitInteractor worldPlaceVisitInteractor = new();

        [GameService, GameElement]
        private readonly WorldPlacePopupShower worldPlacePopupShower = new();
    }
}