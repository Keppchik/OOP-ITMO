using lab3.interfaces;

namespace lab3.DiscountClasses;

public class NoDiscountStrategy : IDiscountStrategy
{
    public decimal ApplyDiscount(decimal amount) => amount;
}