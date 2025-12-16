using lab3.interfaces;

namespace lab3.DiscountClasses;

public class PercentageDiscountStrategy : IDiscountStrategy
{
    public decimal Percentage { get; }
    
    public PercentageDiscountStrategy(decimal percentage)
    {
        Percentage = percentage;
    }
    
    public decimal ApplyDiscount(decimal amount)
    {
        return amount - (amount * Percentage / 100);
    }
}