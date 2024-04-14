using Game.App;
using Services;

namespace Game.Meta
{
    public sealed class InventoryItemsMediator : GameMediator<InventoryItemData[], InventoryService>
    {
        [ServiceInject]
        private InventoryItemsAssetSupplier assetSupplier;

        protected override void SetupFromData(InventoryService service, InventoryItemData[] dataSet)
        {
            var inventory = service.GetInventory();

            for (int i = 0, count = dataSet.Length; i < count; i++)
            {
                var data = dataSet[i];
                var config = this.assetSupplier.GetItem(data.name);
                inventory.AddItemsByPrototype(config.Prototype, data.count);
            }
        }

        protected override void SetupByDefault(InventoryService service)
        {
            //Do nothing...
        }

        protected override InventoryItemData[] ConvertToData(InventoryService service)
        {
            var inventory = service.GetInventory();
            var items = inventory.CountAllItemsInDictionary();
            var count = items.Count;

            var dataSet = new InventoryItemData[count];
            var index = 0;

            foreach (var (name, amount) in items)
            {
                var data = new InventoryItemData
                {
                    name = name,
                    count = amount
                };

                dataSet[index] = data;
                index++;
            }

            return dataSet;
        }
    }
}