using lab3.interfaces;
using lab3.StateClasses;

namespace lab3;

public class OrderContext
{
    public IOrderState State { get; private set; }
    public Order Order { get; }
    
    public OrderContext(Order order)
    {
        State = new PreparingState();
        Order = order;
    }
    
    public void SetState(IOrderState state) => State = state;
    public void Process() => State.Process(this);
    public void Cancel() => State.Cancel(this);
    public void Deliver() => State.Deliver(this);
    public string GetStatus() => State.Status;
}