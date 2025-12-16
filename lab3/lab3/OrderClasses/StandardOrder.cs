namespace lab3;

public class StandardOrder : Order
{
    public StandardOrder(string id, Customer customer) : base(id, customer) { }
    
    public override decimal CalculateTotalPrice()
    {
        var itemsTotalCost = Items.Sum(item => item.Price);
        return itemsTotalCost + DeliveryFee;
    }

    public override int GetEstimatedDeliveryTime() => 45;
}