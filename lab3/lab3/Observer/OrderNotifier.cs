using lab3.interfaces;

namespace lab3.Observer;

public class OrderNotifier : ISubject
{
    public List<IObserver> Observers { get; }
    public OrderContext OrderContext { get; }
    
    public OrderNotifier(OrderContext orderContext)
    {
        Observers = new List<IObserver>();
        OrderContext = orderContext;
    }
    
    public void Attach(IObserver observer) => Observers.Add(observer);
    public void Detach(IObserver observer) => Observers.Remove(observer);

    public void Notify(string message)
    {
        foreach (var observer in Observers)
        {
            observer.Update(message);
        }
    }
    
    public void ProcessOrder()
    {
        OrderContext.Process();
        Notify($"Order {OrderContext.Order.Id} status changed to: {OrderContext.GetStatus()}");
    }
    
    public void DeliverOrder()
    {
        OrderContext.Deliver();
        Notify($"Order {OrderContext.Order.Id} has been delivered");
    }
    
    public void CancelOrder()
    {
        OrderContext.Cancel();
        Notify($"Order {OrderContext.Order.Id} has been cancelled");
    }
}