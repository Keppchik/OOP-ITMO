namespace lab3;

public abstract class OrderFactory
{
    public abstract Order CreateOrder(string id, Customer customer);
}