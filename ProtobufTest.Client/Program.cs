using Grpc.Net.Client;
using ProtobufTest.Server.GrpcService;

Console.WriteLine("Введите 2 числа через запятую");

while (true)
{
    var consoleLine = Console.ReadLine();

    if (consoleLine is null)
    {
        Console.WriteLine("Вы ввели пустую строку");
        continue;
    }

    var consoleSymbols = consoleLine.Split(',');
    if (consoleSymbols.Length != 2)
    {
        Console.WriteLine("Вы ввели не 2 числа");
        continue;
    }

    // Создание gRPC канала
    using var channel = GrpcChannel.ForAddress("https://localhost:7110");

    // Создание клиента
    var client = new Calculator.CalculatorClient(channel);

    // Создайте запрос
    var request = new CalculateRequest { Number1 = int.Parse(consoleSymbols[0]), Number2 = int.Parse(consoleSymbols[1]) };

    // Запрос
    var reply = client.GetSum(request);

    // Вывод ответа на консоль
    Console.WriteLine("Greeting: " + reply.Sum);
}