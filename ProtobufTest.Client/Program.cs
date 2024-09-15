// Создайте gRPC канал
using Grpc.Net.Client;
using ProtobufTest.Server.GrpcService;

using var channel = GrpcChannel.ForAddress("https://localhost:7110");

// Создайте клиента
var client = new Greeter.GreeterClient(channel);

// Создайте запрос
var request = new HelloRequest { Name = "Alice" };

// Отправьте запрос и получите ответ
var reply = await client.SayHelloAsync(request);

// Выведите ответ на консоль
Console.WriteLine("Greeting: " + reply.Message);