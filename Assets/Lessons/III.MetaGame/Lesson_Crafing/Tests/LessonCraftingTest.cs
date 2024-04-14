using Lessons.MetaGame.Crafting;
using Lessons.MetaGame.Inventory;
using NUnit.Framework;

[TestFixture]
public sealed class LessonCraftingTest
{
    private InventoryItemConfig woodItem;
    private InventoryItemConfig stoneItem;
    private InventoryItemConfig steelItem;
    private InventoryItemConfig axeItem;
    private InventoryItemConfig swordItem;

    private InventoryItemReceipt axeReceipt;
    private InventoryItemReceipt swordReceipt;

    private ListInventory inventory;
    private InventoryItemCrafter itemCrafter;

    [SetUp]
    public void Setup()
    {
        this.inventory = new ListInventory();
        this.itemCrafter = new InventoryItemCrafter(this.inventory);

        this.woodItem = Substitute.CreateItem("Wood");
        this.stoneItem = Substitute.CreateItem("Stone");
        this.steelItem = Substitute.CreateItem("Steel");
        this.axeItem = Substitute.CreateItem("Axe");
        this.swordItem = Substitute.CreateItem("Sword");

        this.axeReceipt = Substitute.CreateReceipt(this.axeItem,
            new InventoryItemIngredient
            {
                item = woodItem,
                amount = 2
            }, new InventoryItemIngredient
            {
                item = stoneItem,
                amount = 1
            });


        this.swordReceipt = Substitute.CreateReceipt(this.swordItem,
            new InventoryItemIngredient
            {
                item = woodItem,
                amount = 1
            }, new InventoryItemIngredient
            {
                item = steelItem,
                amount = 1
            });
    }


    [Test]
    public void AxeCrafting()
    {
        //Arrange: (Установка)
        this.inventory.Setup(
            this.woodItem.item.Clone(),
            this.woodItem.item.Clone(),
            this.stoneItem.item.Clone()
        );

        //Act: (Действие) ingredient.item.item.Name- Крафтинг
        this.itemCrafter.Craft(this.axeReceipt);

        //Assert: (Проверка на результат)
        Assert.True(inventory.GetCount(this.woodItem.item.Name) == 0);
        Assert.True(inventory.GetCount(this.stoneItem.item.Name) == 0);
        Assert.True(inventory.GetCount(this.axeItem.item.Name) == 1);
    }

    [Test]
    public void SwordCrafting()
    {
        //Arrange: (Установка)
        this.inventory.AddItem(this.woodItem.item.Clone());
        this.inventory.AddItem(this.steelItem.item.Clone());

        //Act: (Действие) - Крафтинг
        this.itemCrafter.Craft(this.swordReceipt);

        //Assert: (Проверка на результат)
        Assert.True(this.inventory.GetCount(this.woodItem.item.Name) == 0);
        Assert.True(this.inventory.GetCount(this.steelItem.item.Name) == 0);
        Assert.True(this.inventory.GetCount(this.swordItem.item.Name) == 1);
    }

    [Test]
    public void SwordCraftingNotEnougth()
    {
        //Arrange: (Установка)
        this.inventory.AddItem(this.woodItem.item.Clone());

        //Act: (Действие) - Крафтинг
        Assert.Catch(() => this.itemCrafter.Craft(this.swordReceipt));

        //Assert: (Проверка на результат)
        Assert.True(this.inventory.GetCount(this.woodItem.item.Name) == 1);
        Assert.True(this.inventory.GetCount(this.swordItem.item.Name) == 0);
    }
}