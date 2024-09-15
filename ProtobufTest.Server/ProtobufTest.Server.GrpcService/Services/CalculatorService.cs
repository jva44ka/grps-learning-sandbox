using Grpc.Core;

namespace ProtobufTest.Server.GrpcService.Services;

public class CalculatorService : Calculator.CalculatorBase
{
    private readonly ILogger<GreeterService> _logger;

    public CalculatorService(ILogger<GreeterService> logger)
    {
        _logger = logger;
    }

    public override Task<CalculateReply> GetSum(CalculateRequest request, ServerCallContext context)
    {
        Console.WriteLine(context.AuthContext.PeerIdentityPropertyName);
        var sumResult = request.Number1 + request.Number2;
        return Task.FromResult(new CalculateReply { Sum = sumResult });
    }
}