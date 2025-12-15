using lab2.interfaces;
using lab2.Items;

namespace lab2;

class Program
{
    static void Main()
    {
        var inventory = new Inventory(maxWeight: 150);
        
        var sword = new Weapon("Weapon_001", "Excalibur", "Greatest sword ever", 20, 10000, ItemRarity.Legendary, EquipmentSlot.MainHand, 100.0f, 1.5f);
        var sword2 = new Weapon("Weapon_002", "Iron sword", "Avg sword", 15, 500, ItemRarity.Rare, EquipmentSlot.MainHand, 10.0f, 1.0f);
        var shield = new Armor("Armor_001", "Poor Shield", "Made of wood", 30, 100, ItemRarity.Common, EquipmentSlot.OffHand, 10.0f);
        var healPotion = new HealPotion("HealPotion_001", "Great Potion of healling", "Smells like idk grass", 5, 1000, ItemRarity.Rare, 100, 2);
        var questItem = new QuestItem("QuestItem_001", "Ancient Relic", "Made by ancient people", 10, 0, ItemRarity.Rare, "Quest_001");
        
        inventory.AddItem(sword);
        inventory.AddItem(shield);
        inventory.AddItem(healPotion);
        inventory.AddItem(questItem);
        
        inventory.EquipItem(sword.ID);
        inventory.EquipItem(shield.ID);
        
        inventory.UseItem(healPotion.ID);
        
        inventory.UpgradeItem(sword.ID, sword2.ID);
        
        Console.WriteLine(inventory.GetInventoryInfo());
        Console.WriteLine(inventory.GetEquippedItemsInfo());
        
        Console.WriteLine(sword.GetItemInfo());
    }
}