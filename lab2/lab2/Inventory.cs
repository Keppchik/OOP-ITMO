using lab2.interfaces;
namespace lab2;

public class Inventory : IInventory
{
    public List<IItem> Items { get; }
    public Dictionary<EquipmentSlot, IEquippableItem> EquippedItems { get; }
    public int MaxWeight { get; }
    public int CurrentWeight { get; private set; }

    public Inventory(int maxWeight = 100)
    {
        MaxWeight = maxWeight;
        CurrentWeight = 0;
        Items = new List<IItem>();
        EquippedItems = new Dictionary<EquipmentSlot, IEquippableItem>();
    }

    public void AddItem(IItem item)
    {
        if (CurrentWeight + item.Weight <= MaxWeight)
        {
            Items.Add(item);
            CurrentWeight +=  item.Weight;
        }
    }

    public void RemoveItem(string itemID)
    {
        var item = Items.FirstOrDefault(item => item.ID == itemID);
        if (item != null)
        {
            Items.Remove(item);
            CurrentWeight -= item.Weight;

            if (item is IEquippableItem equippedItem && equippedItem.IsEquipped)
            {
                UnequipItem(equippedItem.Slot);
            }
        }
    }

    public void EquipItem(string itemID)
    {
        var item = Items.FirstOrDefault(item => item.ID == itemID) as IEquippableItem;
        if (item != null)
        {
            if (EquippedItems.TryGetValue(item.Slot, out IEquippableItem equippedItem))
            {
                equippedItem.Unequip();
            }
            
            item.Equip();
            EquippedItems[item.Slot] = item;
        }
    }

    public void UnequipItem(EquipmentSlot slot)
    {
        if (EquippedItems.TryGetValue(slot, out IEquippableItem equippedItem))
        {
            equippedItem.Unequip();
            EquippedItems.Remove(slot);
        }
    }

    public void UseItem(string itemID)
    {
        var item = Items.FirstOrDefault(item => item.ID == itemID) as IUsableItem;
        if (item != null)
        {
            item.Use();
            if (item.UsesRemaining <= 0)
            {
                RemoveItem(itemID);
            }
        }
    }

    public void UpgradeItem(string itemID, string itemConsumedForUpgradeID)
    {
        var item = Items.FirstOrDefault(item => item.ID == itemID) as IUpgradableItem;
        var consumeItem = Items.FirstOrDefault(item => item.ID == itemID);
        if (item != null && consumeItem != null && consumeItem.GetType() == item.GetType())
        {
            RemoveItem(itemConsumedForUpgradeID);
            item.Upgrade();
        }
    }

    public string GetInventoryInfo()
    {
        var info = $"Inventory: {CurrentWeight}/{MaxWeight} weight\n" +
                   $"Items ({Items.Count}):\n";
        foreach (var item in Items)
        {
            info += $"{item.Name} ({item.Weight} weight)\n";
        }
        
        return info;
    }

    public string GetEquippedItemsInfo()
    {
        var info = "Equipped Items:\n";
        foreach (var item in EquippedItems)
        {
            info += $"{item.Key}: {item.Value.Name}\n";
        }
        
        return info;
    }
}