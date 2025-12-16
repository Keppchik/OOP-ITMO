using lab3.interfaces;

namespace lab3.DiscountClasses;

public class FixedAmountDiscountStrategy : IDiscountStrategy
{
    public decimal Amount { get; }
    
    public FixedAmountDiscountStrategy(decimal amount)
    {
        Amount = amount;
    }

    public decimal ApplyDiscount(decimal amount) => amount - Amount;
}