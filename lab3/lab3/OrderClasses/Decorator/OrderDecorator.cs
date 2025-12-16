namespace lab3;

public abstract class OrderDecorator : Order
{
    protected Order Order { get; }
    
    protected OrderDecorator(Order order) : base(order.Id, order.Customer)
    {
        Order = order;
        Items.AddRange(order.Items);
    }
}