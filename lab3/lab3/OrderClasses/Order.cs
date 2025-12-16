using lab3.interfaces;

namespace lab3;

public abstract class Order
{
    public string Id { get; }
    public DateTime CreatedAt { get; }
    public List<IMenuItem> Items { get; }
    public Customer Customer { get; }
    public decimal DeliveryFee { get; protected set; }
    
    protected Order(string id, Customer customer)
    {
        Id = id;
        CreatedAt = DateTime.Now;
        Customer = customer;
        Items = new List<IMenuItem>();
        DeliveryFee = 5.0m;
    }
    
    public void AddItem(IMenuItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(IMenuItem item)
    {
        Items.Remove(item);
    }
    
    public abstract decimal CalculateTotalPrice();
    public abstract int GetEstimatedDeliveryTime();
}