using Game.GameEngine.InventorySystem;
using Game.GameEngine.Products;
using Game.Gameplay.Hero;
using GameSystem;
using Sirenix.OdinInspector;

namespace Game.Meta
{
    public sealed class InventoryModule : GameModule
    {
        private readonly StackableInventory inventory = new();
        
        [GameService]
        [ReadOnly, ShowInInspector]
        private InventoryService service = new();

        [GameService]
        [ShowInInspector]
        private InventoryItemConsumer itemConsumer = new();

        [GameService]
        [ShowInInspector]
        private InventoryItemCrafter itemCrafter = new();

        [GameElement]
        [ReadOnly, ShowInInspector]
        private InventoryItemEffectHandler effectsObserver = new();

        public override void ConstructGame(GameContext context)
        {
            this.service.Setup(this.inventory);
            this.itemConsumer.SetInventory(this.inventory);
            this.itemCrafter.SetInventory(this.inventory);

            this.InstallEffectObserver(context);
            this.InstallConsumeHealingKit(context);
            this.InstallProductBuyKit(context);
        }

        private void InstallEffectObserver(GameContext context)
        {
            var heroService = context.GetService<HeroService>();
            this.effectsObserver.Construct(heroService);
            this.effectsObserver.SetInventory(this.inventory);
        }

        private void InstallConsumeHealingKit(GameContext context)
        {
            var heroService = context.GetService<HeroService>();
            this.itemConsumer.AddHandler(new HealingInventoryItemConsumeHandler(heroService));
        }

        private void InstallProductBuyKit(GameContext context)
        {
            var buySystem = context.GetService<ProductBuyer>();
            buySystem.AddCompletor(new InventoryItemBuyCompletor(this.inventory));
        }
        
        [Title("Debug")]
        [Button]
        private void AddItems(InventoryItemConfig itemInfo, int count)
        {
            this.inventory.AddItemsByPrototype(itemInfo.Prototype, count);
        }

        [Button]
        private void RemoveItem(InventoryItemConfig itemInfo, int count)
        {
            this.inventory.RemoveItems(itemInfo.ItemName, count);
        }
    }
}