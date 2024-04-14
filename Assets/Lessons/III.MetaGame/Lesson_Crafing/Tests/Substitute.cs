using Lessons.MetaGame.Crafting;
using Lessons.MetaGame.Inventory;
using UnityEngine;

public static class Substitute
{
    public static InventoryItemConfig CreateItem(string itemName)
    {
        var item = ScriptableObject.CreateInstance<InventoryItemConfig>();
        item.item = new InventoryItem(itemName, InventoryItemFlags.NONE, null);
        return item;
    }

    public static InventoryItemReceipt CreateReceipt(
        InventoryItemConfig result,
        params InventoryItemIngredient[] ingredients
    )
    {
        var receipt = ScriptableObject.CreateInstance<InventoryItemReceipt>();
        receipt.ingredients = ingredients;
        receipt.itemResult = result;
        return receipt;
    }
}