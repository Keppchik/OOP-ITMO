using lab3.interfaces;

namespace lab3.StateClasses;

public class CancelledState : IOrderState
{
    public string Status => "Cancelled";
    
    public void Process(OrderContext context)
    {
        throw new InvalidOperationException("Order has been cancelled and cannot be processed");
    }
    
    public void Cancel(OrderContext context)
    {
        throw new InvalidOperationException("Order has already been cancelled");
    }
    
    public void Deliver(OrderContext context)
    {
        throw new InvalidOperationException("Order has been cancelled and cannot be delivered");
    }
}