namespace lab3;

public class StandardOrderFactory : OrderFactory
{
    public override Order CreateOrder(string id, Customer customer) => new StandardOrder(id, customer);
}