using lab2.interfaces;
namespace lab2.Items;

public class HealPotion : IUsableItem
{
    public string ID { get; }
    public string Name { get; }
    public string Description { get; }
    public int Weight { get; }
    public int Value { get; }
    public ItemRarity Rarity { get; }
    public int UsesRemaining { get; private set; }
    public int HealAmount { get; }
    


    public HealPotion(string id, string name, string description, int weight, int value, ItemRarity rarity, int healAmount, int usesRemaining = 1)
    {
        ID = id;
        Name = name;
        Description = description;
        Weight = weight;
        Value = value;
        Rarity = rarity;
        UsesRemaining = usesRemaining;
        HealAmount = healAmount;
    }

    public string GetItemInfo()
    {
        return $"Heal Potion: {Name}" +
               $"Description: {Description}\n" +
               $"Heal Amount: {HealAmount}\n" +
               $"Uses Remaining: {UsesRemaining}\n" +
               $"Rarity: {Rarity}\n" +
               $"Weight: {Weight}\n" +
               $"Value: {Value}";
    }

    public void Use()
    {
        if (UsesRemaining > 0)
        {
            UsesRemaining--;
        }
    }
}