namespace lab2.interfaces;

public interface IUpgradableItem : IItem
{
    int CurrentLevel { get; }
    int MaxLevel { get; }
    
    void Upgrade();
}