using lab3.interfaces;

namespace lab3.StateClasses;

public class DeliveredState : IOrderState
{
    public string Status => "Delivered";
    
    public void Process(OrderContext context)
    {
        throw new InvalidOperationException("Order has already been delivered and cannot be processed further");
    }

    public void Cancel(OrderContext context)
    {
        throw new InvalidOperationException("Order has already been delivered and cannot be cancelled");
    }

    public void Deliver(OrderContext context)
    {
        throw new InvalidOperationException("Order has already been delivered and cannot be delivered");
    }
}