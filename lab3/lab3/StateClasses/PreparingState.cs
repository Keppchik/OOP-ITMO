using lab3.interfaces;

namespace lab3.StateClasses;

public class PreparingState : IOrderState
{
    public string Status => "Preparing";
    
    public void Process(OrderContext context)
    {
        context.SetState(new InDeliveryState());
    }
    
    public void Cancel(OrderContext context)
    {
        context.SetState(new CancelledState());
    }
    
    public void Deliver(OrderContext context)
    {
        throw new InvalidOperationException("Order is still being prepared and cannot be delivered");
    }
}