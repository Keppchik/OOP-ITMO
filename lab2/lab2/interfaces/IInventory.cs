namespace lab2.interfaces;

public interface IInventory
{
    int MaxWeight { get; }
    int CurrentWeight { get; }
    List<IItem> Items { get; }
    Dictionary<EquipmentSlot, IEquippableItem> EquippedItems { get; }

    void AddItem(IItem item);
    void RemoveItem(string itemID);
    void UseItem(string itemID);
    void EquipItem(string itemID);
    void UnequipItem(EquipmentSlot slot);
    string GetInventoryInfo();
    string GetEquippedItemsInfo();
    void UpgradeItem(string itemID, string itemConsumedForUpgradeID);
}