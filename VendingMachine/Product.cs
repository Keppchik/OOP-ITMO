namespace VendingMachine;

public class Product
{
    public string name { get; }
    public decimal price { get; }
    public int count { get; set; }

    public Product(string Name, decimal Price,  int Count)
    {
        name = Name;
        price = Price;
        count = Count;
    }
}