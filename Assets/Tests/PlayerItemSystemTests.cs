using Equipment;
using NUnit.Framework;
using Sample;

namespace Tests
{
    public class PlayerItemSystemTests
    {
        [Test]
        public void GetInventoryItemsTest()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);

            //Act
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(items[0], item);
        }

        [Test]
        public void AddItemTest()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();
        
            //Act
            playerItemsSystem.AddItem(item);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(items[0], item);
        }
        
        [Test]
        public void AddItemTest_ItemIsNull()
        {
            //Arrange
            Item item = null;
            var playerItemsSystem = new PlayerItemsSystem();
        
            //Act
            playerItemsSystem.AddItem(item);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(0, items.Count);
        }
        
        [Test]
        public void AddItemTest_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();
        
            //Act
            playerItemsSystem.AddItem(item);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(0, items.Count);
        }
        
        [Test]
        public void HasItemTest()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();

            //Act
            playerItemsSystem.AddItem(item);

            //Asset
            Assert.IsTrue(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void HasItemTest_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();

            //Act
            playerItemsSystem.AddItem(item);

            //Asset
            Assert.IsFalse(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void HasItemTest_ItemIsNull()
        {
            //Arrange
            var playerItemsSystem = new PlayerItemsSystem();

            //Asset
            Assert.IsFalse(playerItemsSystem.HasItem(null));
        }

        [Test]
        public void RemoveItemTest()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);

            //Act
            playerItemsSystem.RemoveItem(item.Name);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(0, items.Count);
        }
        
        [Test]
        public void RemoveItemTest_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.NONE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);

            //Act
            playerItemsSystem.RemoveItem(string.Empty);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(1, items.Count);
        }
        
        [Test]
        public void RemoveItemTest_ItemIsNull()
        {
            //Arrange
            var playerItemsSystem = new PlayerItemsSystem();

            //Act
            playerItemsSystem.RemoveItem(null);
            var items = playerItemsSystem.GetInventoryItems();

            //Asset
            Assert.AreEqual(0, items.Count);
        }

        [Test]
        public void GetEquipmentItems()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
        
            //Act
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(equipableItems[EquipmentType.HEAD], item);
        }
        
        [Test]
        public void GetEquipmentItems_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
        
            //Act
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }

        [Test]
        public void EquipItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(equipableItems[EquipmentType.HEAD], item);
            Assert.IsFalse(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void EquipItem_ItemIsNull()
        {
            //Arrange
            Item item = null;
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }
        
        [Test]
        public void EquipItem_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }

        [Test]
        public void RemoveEquippedItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.RemoveEquippedItem(EquipmentType.HEAD);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
            Assert.IsTrue(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void RemoveEquippedItem_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.RemoveEquippedItem(EquipmentType.HEAD);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }
        
        [Test]
        public void RemoveEquippedItem_ItemIsNull()
        {
            //Arrange
            Item item = null;
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.RemoveEquippedItem(EquipmentType.HEAD);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }

        [Test]
        public void HasEquippedItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(equipableItems[EquipmentType.HEAD], item);
            Assert.IsTrue(playerItemsSystem.HasEquippedItem(EquipmentType.HEAD));
            Assert.IsFalse(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void HasEquippedItem_ItemNameIsEmpty()
        {
            //Arrange
            var item = new Item(string.Empty, ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }
        
        [Test]
        public void HasEquippedItem_ItemIsNull()
        {
            //Arrange
            Item item = null;
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(0, equipableItems.Count);
        }

        [Test]
        public void ChangeEquippedItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var otherItem = new Item("Item2", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.AddItem(otherItem);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.ChangeEquippedItem(EquipmentType.HEAD, otherItem);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(otherItem.Name, equipableItems[EquipmentType.HEAD].Name);
            Assert.IsFalse(playerItemsSystem.HasItem(otherItem.Name));
            Assert.IsTrue(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void ChangeEquippedItem_SameItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            playerItemsSystem.AddItem(item);
            
            //Act
            playerItemsSystem.ChangeEquippedItem(EquipmentType.HEAD, item);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.IsTrue(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void ChangeEquippedItem_HaveNotItemInInventory()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var otherItem = new Item("Item2", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.ChangeEquippedItem(EquipmentType.HEAD, otherItem);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(item.Name, equipableItems[EquipmentType.HEAD].Name);
            Assert.IsFalse(playerItemsSystem.HasItem(item.Name));
        }
        
        [Test]
        public void ChangeEquippedItem_ItemIsNull()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            Item otherItem = null;
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.AddItem(otherItem);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            playerItemsSystem.ChangeEquippedItem(EquipmentType.HEAD, otherItem);
            var equipableItems = playerItemsSystem.GetEquipmentItems();

            //Asset
            Assert.AreEqual(1, equipableItems.Count);
            Assert.AreEqual(item.Name, equipableItems[EquipmentType.HEAD].Name);
            Assert.IsFalse(playerItemsSystem.HasItem(item.Name));
        }

        [Test]
        public void GetEquippedItem()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            var equipableItem = playerItemsSystem.GetEquippedItem(EquipmentType.HEAD);

            //Asset
            Assert.AreEqual(equipableItem.Name, item.Name);
            Assert.IsTrue(playerItemsSystem.HasEquippedItem(EquipmentType.HEAD));
        }
        
        [Test]
        public void GetEquippedItem_ItemIsNull()
        {
            //Arrange
            Item item = null;
            var playerItemsSystem = new PlayerItemsSystem();
            playerItemsSystem.AddItem(item);
            playerItemsSystem.EquipItem(EquipmentType.HEAD, item);
            
            //Act
            var equipableItem = playerItemsSystem.GetEquippedItem(EquipmentType.HEAD);

            //Asset
            Assert.AreEqual(null, equipableItem);
        }

        [Test]
        public void EquipmentOnItemAdded()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var equipment = new Equipment.Equipment();
            
            //Act
            var checker = false;
            equipment.OnItemAdded += _ => { checker = true; };
            equipment.AddItem(EquipmentType.HEAD, item);

            //Asset
            Assert.IsTrue(checker);
        }
        
        [Test]
        public void EquipmentOnItemRemoved()
        {
            //Arrange
            var item = new Item("Item1", ItemFlags.EQUPPABLE);
            var equipment = new Equipment.Equipment();
            equipment.AddItem(EquipmentType.HEAD, item);
            
            //Act
            var checker = false;
            equipment.OnItemRemoved += _ => { checker = true; };
            equipment.RemoveItem(EquipmentType.HEAD);

            //Asset
            Assert.IsTrue(checker);
        }
        
        [Test]
        public void EquipmentOnItemChanged()
        {
            //Arrange
            var item = new Item("Item", ItemFlags.EQUPPABLE);
            var item1 = new Item("Item1", ItemFlags.EQUPPABLE);
            var equipment = new Equipment.Equipment();
            equipment.AddItem(EquipmentType.HEAD, item);
            
            //Act
            var checker = false;
            equipment.OnItemChanged += _ => { checker = true; };
            equipment.ChangeItem(EquipmentType.HEAD, item1);

            //Asset
            Assert.IsTrue(checker);
        }
    }
}