namespace lab2.interfaces;

public interface IUsableItem : IItem
{
    int UsesRemaining { get; }
    
    void Use();
}