using GameSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Hero
{
    public sealed class HeroModule : GameModule
    {
        [Title("Services")]
        [GameService]
        [ReadOnly, ShowInInspector]
        private HeroService heroService = new();

        [GameService]
        [ReadOnly, ShowInInspector]
        private HeroWalkableSurface walkableSurface = new();

        [Title("Detection")]
        [GameElement]
        [ReadOnly, ShowInInspector]
        private EntityDetectService detectService = new();

        [SerializeField]
        private EnemyDetector enemyDetectController = new();

        [SerializeField]
        private ResourceDetector resourceDetectController = new();

        [Title("Controllers")]
        [GameElement]
        [ReadOnly, ShowInInspector]
        private HeroMoveController moveController = new();

        [GameElement]
        [ReadOnly, ShowInInspector]
        private HeroRespawnController respawnController = new();

        [GameElement]
        [ReadOnly, ShowInInspector]
        private HeroEnableController enableController = new();

        [Title("Visitors")]
        [GameElement]
        [ReadOnly, ShowInInspector]
        private ConveyorVisitor conveyorVisitController = new();

        [GameElement]
        [SerializeField]
        private VendorVisitor vendorVisitController = new();

        [GameElement]
        [SerializeField]
        private WorldPlaceVisitor worldPlaceVisitController = new();

        [GameElement]
        [SerializeField]
        private DialogueVisitor dialogueVisitor = new();

        [Title("Interactors")]
        [GameService, GameElement]
        [SerializeField]
        private RespawnInteractor respawnInteractor;

        [GameElement]
        [SerializeField]
        private MeleeCombatInteractor meleeCombatInteractor;

        [GameElement]
        [SerializeField]
        private HarvestResourceInteractor harvestResourceInteractor;

        public override void ConstructGame(GameContext context)
        {
            base.ConstructGame(context);
            this.ConstructDetector();
        }

        private void ConstructDetector()
        {
            this.detectService.AddListener(this.enemyDetectController);
            this.detectService.AddListener(this.resourceDetectController);
        }
    }
}