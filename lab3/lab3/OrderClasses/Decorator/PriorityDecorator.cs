namespace lab3;

public class PriorityDecorator : OrderDecorator
{
    private decimal PriorityFee = 3.0m;

    public PriorityDecorator(Order order) : base(order) { }

    public override decimal CalculateTotalPrice() => Order.CalculateTotalPrice() + PriorityFee;

    public override int GetEstimatedDeliveryTime() => Order.GetEstimatedDeliveryTime() - 10;
}