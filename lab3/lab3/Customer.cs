using lab3.interfaces;

namespace lab3;

public class Customer : IObserver
{
    public string Name { get; }
    public string Email { get; }
    public string Phone { get; }
    
    public Customer(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
    
    public void Update(string message)
    {
        Console.WriteLine($"Notification for {Name}: {message}");
    }
}