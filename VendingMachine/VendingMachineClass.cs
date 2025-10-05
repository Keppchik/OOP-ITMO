namespace VendingMachine;

public class VendingMachine
{
    private List<Product> products;
    private decimal _insertedMoney;
    private decimal _earnedMoney;
    private string _password;

    public VendingMachine()
    {
        products = new List<Product>();
        _insertedMoney = 0;
        _earnedMoney = 0;
        _password = "qwerty";
    }

    public decimal getBalance()
    {
        return _insertedMoney;
    }

    public void returnInsertedMoney()
    {
        Console.Clear();
        var tens = (int)_insertedMoney / 10;
        var fives = (int)(_insertedMoney - 10*tens) / 5;
        var twos = (int)(_insertedMoney - 10*tens - 5*fives) / 2;
        var ones = (int)_insertedMoney - 10*tens - 5*fives - 2*twos;
        Console.WriteLine($"Выдано монет номиналом 10: {tens}\nноминалом 5: {fives}\nноминалом 2: {twos}\nноминалом 1: {ones}");
        _insertedMoney = 0;
        Console.Write("Нажмите на любую кнопку, чтобы вернуться...");
        Console.ReadKey();
    }
    
    public void returnEarnedMoney()
    {
        Console.Clear();
        var tens = (int)_earnedMoney / 10;
        var fives = (int)(_earnedMoney - 10*tens) / 5;
        var twos = (int)(_earnedMoney - 10*tens - 5*fives) / 2;
        var ones = (int)_earnedMoney - 10*tens - 5*fives - 2*twos;
        Console.WriteLine($"Выдано монет номиналом 10: {tens}\nноминалом 5: {fives}\nноминалом 2: {twos}\nноминалом 1: {ones}");
        _earnedMoney = 0;
        Console.Write("Нажмите на любую кнопку, чтобы вернуться...");
        Console.ReadKey();
    }

    public void insertMoney()
    {
        var money = 0;
        Console.Clear();
        Console.WriteLine("Вставьте монеты номиналом 10, 5, 2 или 1  (напишите наминал и количество монет, чтобы закончить вставлять монеты напишите 'Отмена')");
        while (true)
        {
            var line = Console.ReadLine().Split();
            
            if (line[0].ToLower() == "отмена") {
                break;
            }
            
            try 
            {
                if (line.Length == 2)
                {
                    if (new[] { "10", "5", "2", "1" }.Contains(line[0]))
                    {
                        money += int.Parse(line[0]) * int.Parse(line[1]);
                    }
                    else
                    {
                        Console.WriteLine("Нет монет такого номинала");
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат ввода монет");
                }
            }
            catch 
            { 
                Console.WriteLine("Неверный формат ввода монет");
            }
        }
        _insertedMoney += money;
    }
    
    public void showProducts()
    {
        Console.Clear();
        if (products.Count < 1)
        {
            Console.WriteLine("В автомате нет товаров");
            Console.Write("Нажмите на любую кнопку, чтобы вернуться...");
            Console.ReadKey();
        } else
        {
            Console.WriteLine("Список доступных товаров:");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.name} стоит {product.price}₽, доступно: {product.count} шт.");
            }
            buyProduct();
        }
    }

    public void addProduct(string name, decimal price, int count = 1)
    {
        Product newProduct = products.Find(x => x.name == name);
        if (newProduct != null)
        {
            newProduct.count += count;
        }
        else
        {
            products.Add(new Product(name,  price, count));   
        }
    }

    public void buyProduct()
    {
        Console.WriteLine("Напишите название продукта, которого хотите купить. Напишите 'Отмена' для отмены");
        string name = Console.ReadLine();
        if (name.ToLower() == "отмена")
        {
            return;
        }
        Product chosenProduct = products.Find(x => x.name == name);
        while (chosenProduct == null || chosenProduct.count < 1)
        {
            Console.WriteLine("Нет продукта с таким названием или товар закончился. Напишите название ещё раз или напишите 'Отмена'");
            name = Console.ReadLine();
            if (name.ToLower() == "отмена")
            {
                return;
            }
            chosenProduct = products.Find(x => x.name == name);
        }
        
        if (_insertedMoney >= chosenProduct.price)
        {
            _insertedMoney -= chosenProduct.price;
            _earnedMoney += chosenProduct.price;
            chosenProduct.count -= 1;
            Console.WriteLine("Товар успешно приобретен!");
            Console.Write("Нажмите на любую кнопку, чтобы вернуться...");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Недостаточно средств");
            Console.Write("Нажмите на любую кнопку, чтобы вернуться...");
            Console.ReadKey();
        }
    }

    public void adminPanel()
    {
        Console.WriteLine("Введите пароль");
        string password = Console.ReadLine();
        if (password == _password)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Админ панель");
                Console.WriteLine("Напишите 'Пополнить', чтобы пополнить ассортимент");
                Console.WriteLine("Напишите 'Деньги', чтобы собрать заработанные деньги");
                Console.WriteLine("Напишите 'Отмена', чтобы вернуться");
                string input = Console.ReadLine();
                if (input.ToLower() == "отмена")
                {
                    break;
                }

                if (input.ToLower() == "деньги")
                {
                    Console.Clear();
                    returnEarnedMoney();
                }

                if (input.ToLower() == "пополнить")
                {
                    Console.Clear();
                    Console.WriteLine("Напишите название продукта, его цену и количество (напишите 'Отмена', чтобы закончить)");
                    while (true)
                    {
                        var product = Console.ReadLine().Split();
                        if (product[0].ToLower() == "отмена")
                        {
                            break;
                        }
                        
                        try
                        {
                            addProduct(product[0], decimal.Parse(product[1]), int.Parse(product[2]));
                        }
                        catch
                        {
                            Console.WriteLine("Неправильный формат ввода нового товара");
                        }
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Неправильный пароль");
            Console.Write("Нажмите на любую кнопку...");
            Console.ReadKey();
        }
    }
}