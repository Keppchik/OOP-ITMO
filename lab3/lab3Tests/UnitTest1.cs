using lab3;
using lab3.DiscountClasses;
using Xunit;
using Assert = Xunit.Assert;

namespace lab3Tests;

public class Tests
{
    [Fact]
    public void CreateStandardOrder_ShouldReturnOrderWithCorrectId()
    {
        var service = new DeliveryService();
        var factory = new StandardOrderFactory();
        
        var order = service.CreateOrder("Иван", "ivan@test.com", "1234567890", factory);
        
        Assert.StartsWith("ORD_", order.Id);
        Assert.IsType<StandardOrder>(order);
    }

    [Fact]
    public void ExpressOrder_ShouldHaveHigherDeliveryFee()
    {
        var service = new DeliveryService();
        var standardFactory = new StandardOrderFactory();
        var expressFactory = new ExpressOrderFactory();
        
        var standardOrder = service.CreateOrder("Иван", "a@b.com", "123", standardFactory);
        var expressOrder = service.CreateOrder("Петр", "b@c.com", "456", expressFactory);
        
        Assert.Equal(5.0m, standardOrder.DeliveryFee);
        Assert.Equal(10.0m, expressOrder.DeliveryFee);
    }

    [Fact]
    public void OrderState_ShouldTransitionCorrectly()
    {
        var order = new StandardOrder("TEST123", new Customer("Test", "test@test.com", "123"));
        var context = new OrderContext(order);
        
        Assert.Equal("Preparing", context.GetStatus());

        context.Process();
        Assert.Equal("In Delivery", context.GetStatus());

        context.Deliver();
        Assert.Equal("Delivered", context.GetStatus());
    }

    [Fact]
    public void DiscountStrategy_ShouldApplyCorrectDiscount()
    {
        var percentageStrategy = new PercentageDiscountStrategy(10);
        var fixedStrategy = new FixedAmountDiscountStrategy(5);
        var calculator = new DiscountCalculator(percentageStrategy);
        
        var result1 = calculator.CalculateFinalCost(100);
        Assert.Equal(90, result1);

        calculator.SetStrategy(fixedStrategy);
        var result2 = calculator.CalculateFinalCost(100);
        Assert.Equal(95, result2);
    }

    [Fact]
    public void Decorator_ShouldAddAdditionalFeatures()
    {
        var order = new StandardOrder("TEST123", new Customer("Test", "test@test.com", "123"));
        var priorityOrder = new PriorityDecorator(order);
        
        var originalTotal = order.CalculateTotalPrice();
        var decoratedTotal = priorityOrder.CalculateTotalPrice();
        
        Assert.Equal(decoratedTotal, originalTotal + 3.0m);
    }
}