using lab3.interfaces;

namespace lab3.DiscountClasses;

public class DiscountCalculator
{
    public IDiscountStrategy Strategy { get; private set; }
    
    public DiscountCalculator(IDiscountStrategy strategy)
    {
        Strategy = strategy;
    }

    public void SetStrategy(IDiscountStrategy strategy) => Strategy = strategy;
    
    public decimal CalculateFinalCost(decimal amount) => Strategy.ApplyDiscount(amount);
}