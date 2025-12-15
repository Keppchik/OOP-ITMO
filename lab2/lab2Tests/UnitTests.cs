using lab2;
using lab2.interfaces;
using lab2.Items;
using Xunit;

namespace lab2Tests;

public class InventoryTests
{
    [Fact]
    public void AddItem()
    {
        var inventory = new Inventory();
        var item = new Weapon("1", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15f, 1.0f);
        
        inventory.AddItem(item);
        
        Assert.Single(inventory.Items);
        Assert.Equal(10, inventory.CurrentWeight);
    }

    [Fact]
    public void AddItem_WeightLimit()
    {
        var inventory = new Inventory(10);
        var item = new Weapon("1", "Sword", "A sharp sword", 15, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f);
        
        inventory.AddItem(item);
        
        Assert.Empty(inventory.Items);
        Assert.Equal(0, inventory.CurrentWeight);
    }

    [Fact]
    public void RemoveItem()
    {
        var inventory = new Inventory();
        var item = new Weapon("1", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f);
        inventory.AddItem(item);
        
        inventory.RemoveItem("1");
        
        Assert.Empty(inventory.Items);
        Assert.Equal(0, inventory.CurrentWeight);
    }

    [Fact]
    public void EquipItem()
    {
        var inventory = new Inventory();
        var item = new Weapon("1", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f);
        inventory.AddItem(item);
        
        inventory.EquipItem("1");
        
        Assert.True(item.IsEquipped);
        Assert.Single(inventory.EquippedItems);
        Assert.Equal(item, inventory.EquippedItems[EquipmentSlot.MainHand]);
    }

    [Fact]
    public void UseItem()
    {
        var inventory = new Inventory(100);
        var potion = new HealPotion("1", "Health Potion", "Heals wounds", 1, 50,
            ItemRarity.Common, 50);
        inventory.AddItem(potion);

        inventory.UseItem("1");
        
        Assert.Equal(0, potion.UsesRemaining);
    }

    [Fact]
    public void UpgradeItem()
    {
        var inventory = new Inventory();
        var weapon = new Weapon("1", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f, maxLevel: 3);
        var weapon2 = new Weapon("2", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f, maxLevel: 3);
        inventory.AddItem(weapon);
        inventory.AddItem(weapon2);
        
        inventory.UpgradeItem(weapon.ID, weapon2.ID);
        
        Assert.Equal(2, weapon.CurrentLevel);
        Assert.True(weapon.Damage > 15);
    }
    
    [Fact]
    public void Inventory_GetInventoryInfo_ShouldReturnCorrectString()
    {
        var inventory = new Inventory();
        var item = new Weapon("1", "Sword", "A sharp sword", 10, 100,
            ItemRarity.Common, EquipmentSlot.MainHand, 15, 1.0f);
        inventory.AddItem(item);
        
        var info = inventory.GetInventoryInfo();
        
        Assert.Contains("Inventory:", info);
        Assert.Contains("Sword", info);
    }
}