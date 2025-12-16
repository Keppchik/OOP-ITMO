namespace lab3;

public class Program
{
    static void Main()
    {
        var deliveryService = new DeliveryService();
        
        deliveryService.AddMenuItem(new MenuItem("Пицца", "Вкусная", 12.0m));
        deliveryService.AddMenuItem(new MenuItem("Бургер", "Невкусный",8.0m));
        
        var order = deliveryService.CreateOrder(
            "Иван",
            "ivan@mail.com",
            "12345",
            new StandardOrderFactory()
        );
        
        deliveryService.AddItemToOrder(order.Id, "Пицца");
        
        var status = deliveryService.GetOrderStatus(order.Id);
        Console.WriteLine(status);
        
        deliveryService.ProcessOrder(order.Id);
        
        status = deliveryService.GetOrderStatus(order.Id);
        Console.WriteLine(status);
        
        deliveryService.DeliverOrder(order.Id);
        
        var total = deliveryService.CalculateOrderTotalCost(order.Id);
        
        Console.WriteLine(total);
    }
}