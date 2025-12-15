using lab2.interfaces;
namespace lab2.Items;

public class Armor : IEquippableItem, IUpgradableItem
{
    public string ID { get; }
    public string Name { get; }
    public string Description { get; }
    public int Weight { get; }
    public int Value { get; private set; }
    public ItemRarity Rarity { get; }
    public EquipmentSlot Slot { get; }
    public bool IsEquipped { get; private set; }
    public float Defence { get; private set; }
    public int CurrentLevel { get; private set; }
    public int MaxLevel { get; }

    public Armor(string id, string name, string description, int weight, int value, ItemRarity rarity,
        EquipmentSlot slot, float defence, int currentLevel = 1, int maxLevel = 10, bool isEquipped = false)
    {
        ID = id;
        Name = name;
        Description = description;
        Weight = weight;
        Value = value;
        Rarity = rarity;
        Slot = slot;
        IsEquipped = isEquipped;
        Defence = defence;
        CurrentLevel = currentLevel;
        MaxLevel = maxLevel;
    }

    public string GetItemInfo()
    {
        return $"Armor: {Name} (Lvl {CurrentLevel})\n" +
               $"Description: {Description}\n" +
               $"Defence: {Defence}\n" +
               $"Rarity: {Rarity}\n" +
               $"Weight: {Weight}\n" +
               $"Value: {Value}";
    }
    
    public void Equip()
    {
        IsEquipped = true;
    }

    public void Unequip()
    {
        IsEquipped = false;
    }

    public void Upgrade()
    {
        if (MaxLevel > CurrentLevel)
        {
            CurrentLevel++;
            Defence *= 1.4f;
            Value = (int)(Value * 1.2f);
        }
    }
}