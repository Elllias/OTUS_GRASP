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
    }
}