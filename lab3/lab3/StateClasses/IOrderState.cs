namespace lab3.interfaces;

public interface IOrderState
{
    void Process(OrderContext context);
    void Cancel(OrderContext context);
    void Deliver(OrderContext context);
    string Status { get; }
}