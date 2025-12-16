using lab3.interfaces;

namespace lab3;

public class MenuItem : IMenuItem
{
    public string Name { get; }
    public string Description { get; }
    public decimal Price { get; }
    
    public MenuItem(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }
}