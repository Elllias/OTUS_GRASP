namespace Game.GameEngine.InventorySystem
{
    public interface IInventoryItemConsumeHandler
    {
        void OnConsume(InventoryItem item);
    }
}