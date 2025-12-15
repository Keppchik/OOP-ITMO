namespace lab2.interfaces;

public interface IEquippableItem : IItem
{
    EquipmentSlot Slot { get; }
    bool IsEquipped { get; }
    
    void Equip();
    void Unequip();
}

public enum EquipmentSlot
{
    Head,
    Body,
    Legs,
    Feet,
    MainHand,
    OffHand,
    Accessory
}