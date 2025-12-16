using lab3.interfaces;

namespace lab3.StateClasses;

public class InDeliveryState : IOrderState
{
    public string Status => "In Delivery";
    
    public void Process(OrderContext context)
    {
        context.SetState(new DeliveredState());
    }
    
    public void Cancel(OrderContext context)
    {
        throw new InvalidOperationException("Order is in delivery and cannot be cancelled");
    }
    
    public void Deliver(OrderContext context)
    {
        context.SetState(new DeliveredState());
    }
}