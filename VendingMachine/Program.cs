var vendingMachine = new VendingMachine.VendingMachine();

while (true)
{
    Console.Clear();
    Console.WriteLine($"Вендинговый автомат, ваш баланс = {vendingMachine.getBalance()}₽");
    Console.WriteLine("Напишите 'Список', чтобы посмотреть список товаров");
    Console.WriteLine("Напишите 'Монеты', чтобы вставить монеты");
    Console.WriteLine("Напишите 'Сдача', чтобы получить сдачу или вернуть внесенные монеты");
    Console.WriteLine("Напишите 'Админ', чтобы открыть панель администратора");
    
    string input = Console.ReadLine().ToLower();
    switch (input)
    {
        case "список":
            vendingMachine.showProducts();
            break;
        case "монеты":
            vendingMachine.insertMoney();
            break;
        case "сдача":
            vendingMachine.returnInsertedMoney();
            break;
        case "админ":
            vendingMachine.adminPanel();
            break;
        default: 
            Console.Write("Неизвестная команда. Нажмите на любую кнопку...");
            Console.ReadKey();
            break;
    };
}