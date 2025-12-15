using lab2.interfaces;
namespace lab2.Items;

public class Weapon : IEquippableItem, IUpgradableItem
{
    public string ID { get; }
    public string Name { get; }
    public string Description { get; }
    public int Weight { get; }
    public int Value { get; private set; }
    public ItemRarity Rarity { get; }
    public EquipmentSlot Slot { get; }
    public bool IsEquipped { get; private set; }
    public float Damage { get; private set; }
    public float AttackSpeed  { get; }
    public int CurrentLevel { get; private set; }
    public int MaxLevel { get; }

    public Weapon(string id, string name, string description, int weight, int value, ItemRarity rarity,
        EquipmentSlot slot, float damage, float attackSpeed, int currentLevel = 1, int maxLevel = 10, bool isEquipped = false)
    {
        ID = id;
        Name = name;
        Description = description;
        Weight = weight;
        Value = value;
        Rarity = rarity;
        Slot = slot;
        IsEquipped = isEquipped;
        Damage = damage;
        AttackSpeed = attackSpeed;
        CurrentLevel = currentLevel;
        MaxLevel = maxLevel;
    }

    public string GetItemInfo()
    {
        return $"Weapon: {Name} (Lvl {CurrentLevel})\n" +
               $"Description: {Description}\n" +
               $"Damage: {Damage}\n" +
               $"Attack Speed: {AttackSpeed}\n" +
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
            Damage *= 1.4f;
            Value = (int)(Value * 1.2f);
        }
    }
}