namespace lab3;

public class ExpressOrderFactory : OrderFactory
{
    public override Order CreateOrder(string id, Customer customer) => new ExpressOrder(id, customer);
}