namespace lab2.interfaces;

public interface IItem
{
    string ID { get; }
    string Name { get; }
    string Description { get; }
    int Weight { get; }
    int Value { get; }
    ItemRarity Rarity { get; }

    string GetItemInfo();
}

public enum ItemRarity
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary,
    QuestItem
}