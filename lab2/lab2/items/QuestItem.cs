using lab2.interfaces;
namespace lab2.Items;

public class QuestItem : IItem
{
    public string ID { get; }
    public string Name { get; }
    public string Description { get; }
    public int Weight { get; }
    public int Value { get; }
    public ItemRarity Rarity { get; }
    public string QuestID { get; }

    public QuestItem(string id, string name, string description, int weight, int value, ItemRarity rarity,  string questID)
    {
        ID = id;
        Name = name;
        Description = description;
        Weight = weight;
        Value = value;
        Rarity = rarity;
        QuestID = questID;
    }

    public string GetItemInfo()
    {
        return $"Quest Item: {Name}" +
               $"Description: {Description}\n" +
               $"Quest ID: {QuestID}\n" +
               $"Rarity: {Rarity}\n" +
               $"Weight: {Weight}\n" +
               $"Value: {Value}";
    }
}