namespace lab3;

public class ExpressOrder : Order
{
    public ExpressOrder(string id, Customer customer) : base(id, customer)
    {
        DeliveryFee = 10.0m;
    }

    public override decimal CalculateTotalPrice()
    {
        var itemsTotalCost = Items.Sum(item => item.Price);
        return itemsTotalCost + DeliveryFee;
    }
    
    public override int GetEstimatedDeliveryTime() => 20;
}