using Game.GameEngine.InventorySystem;
using UnityEngine;

namespace Game.Meta
{
    public sealed class InventoryItemPresentationModel : IInventoryItemPresentationModel
    {
        public string Title
        {
            get { return this.item.Metadata.title; }
        }

        public string Description
        {
            get { return this.item.Metadata.decription; }
        }

        public Sprite Icon
        {
            get { return this.item.Metadata.icon; }
        }

        private readonly InventoryItem item;

        private readonly InventoryItemConsumer consumeManager;

        public InventoryItemPresentationModel(InventoryItem item, InventoryItemConsumer consumeManager)
        {
            this.item = item;
            this.consumeManager = consumeManager;
        }
        
        public bool IsStackableItem()
        {
            return this.item.FlagsExists(InventoryItemFlags.STACKABLE);
        }

        public void GetStackInfo(out int current, out int size)
        {
            var component = this.item.GetComponent<IComponent_Stackable>();
            current = component.Value;
            size = component.Size;
        }

        public bool IsConsumableItem()
        {
            return this.item.FlagsExists(InventoryItemFlags.CONSUMABLE);
        }

        public bool CanConsumeItem()
        {
            return this.consumeManager.CanConsumeItem(this.item);
        }

        public void OnConsumeClicked()
        {
            if (this.consumeManager.CanConsumeItem(this.item))
            {
                this.consumeManager.ConsumeItem(this.item);
            }
        }
    }
}