using lab3.DiscountClasses;
using lab3.interfaces;
using lab3.Observer;

namespace lab3;

public class DeliveryService
{
    public List<IMenuItem> Menu { get; }
    public List<OrderContext> Orders { get; }
    public List<OrderNotifier> Notifiers { get; }
    public int OrderCounter { get; private set; }
    
    public DeliveryService()
    {
        Menu = new List<IMenuItem>();
        Orders = new List<OrderContext>();
        Notifiers = new List<OrderNotifier>();
        OrderCounter = 1;
    }
    
    public void AddMenuItem(IMenuItem item) => Menu.Add(item);
    
    public Order CreateOrder(string customerName, string customerEmail, string customerPhone, OrderFactory factory)
    {
        var customer = new Customer(customerName, customerEmail, customerPhone);
        var orderId = $"ORD_{OrderCounter++}";  ///////
                                               
        var order = factory.CreateOrder(orderId, customer);
        var orderContext = new OrderContext(order);
        Orders.Add(orderContext);
        
        var notifier = new OrderNotifier(orderContext);
        notifier.Attach(customer);
        notifier.Notify($"Order created with ID: {orderId}");
        Notifiers.Add(notifier);
        
        return order;
    }
    
    public void AddItemToOrder(string orderId, string menuItemName)
    {
        var orderContext = Orders.FirstOrDefault(order => order.Order.Id == orderId);
        var item = Menu.FirstOrDefault(menuItem => menuItem.Name == menuItemName);
        
        if (orderContext != null && item != null)
        {
            orderContext.Order.AddItem(item);
        }
    }
    
    public void ProcessOrder(string orderId)
    {
        var orderContext = Orders.FirstOrDefault(order => order.Order.Id == orderId);

        if (orderContext != null)
        {
            var notifier = Notifiers.FirstOrDefault(notifier => notifier.OrderContext == orderContext);
            if (notifier != null)
            {
                notifier.ProcessOrder();
            }
        }
    }
    
    public void DeliverOrder(string orderId)
    {
        var orderContext = Orders.FirstOrDefault(order => order.Order.Id == orderId);

        if (orderContext != null)
        {
            var notifier = Notifiers.FirstOrDefault(notifier => notifier.OrderContext == orderContext);
            if (notifier != null)
            {
                notifier.DeliverOrder();
            }
        }
    }
    
    public void CancelOrder(string orderId)
    {
        var orderContext = Orders.FirstOrDefault(order => order.Order.Id == orderId);

        if (orderContext != null)
        {
            var notifier = Notifiers.FirstOrDefault(notifier => notifier.OrderContext == orderContext);
            if (notifier != null)
            {
                notifier.CancelOrder();
            }
        }
    }

    public string GetOrderStatus(string orderId)
    {
        var order = Orders.FirstOrDefault(order => order.Order.Id == orderId);
        if (order != null)
        {
            return order.GetStatus();
        }

        return "Not Found";
    }

    public decimal CalculateOrderTotalCost(string orderId, IDiscountStrategy discountStrategy = null)
    {
        var order = Orders.FirstOrDefault(order => order.Order.Id == orderId);
        if (order != null)
        {
            var total = order.Order.CalculateTotalPrice();

            if (discountStrategy != null)
            {
                var calculator = new DiscountCalculator(discountStrategy);
                total = calculator.CalculateFinalCost(total);
            }

            return total;
        }

        return 0.0m;
    }
}