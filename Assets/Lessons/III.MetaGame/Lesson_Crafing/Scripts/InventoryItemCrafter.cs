using System;
using Lessons.MetaGame.Inventory;

namespace Lessons.MetaGame.Crafting
{
    public sealed class InventoryItemCrafter
    {
        private readonly ListInventory inventory;

        public InventoryItemCrafter(ListInventory inventory)
        {
            this.inventory = inventory;
        }

        public bool CanCraft(InventoryItemReceipt receipt)
        {
            foreach (var ingredient in receipt.ingredients)
            {
                var currentAmount = this.inventory.GetCount(ingredient.item.item.Name);
                if (currentAmount < ingredient.amount)
                {
                    return false;
                }
            }

            return true;
        }

        public void Craft(InventoryItemReceipt receipt)
        {
            if (!this.CanCraft(receipt))
            {
                throw new Exception("Not enouth resources");
            }

            foreach (var ingredient in receipt.ingredients)
            {
                this.inventory.RemoveItems(ingredient.item.item.Name, ingredient.amount);
            }

            var resultItem = receipt.itemResult.item.Clone();
            this.inventory.AddItem(resultItem);
        }
    }
}