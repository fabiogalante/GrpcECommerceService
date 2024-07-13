
using Grpc.Core;
using CalculatorDemo;

namespace GrpcDemo.Services;


public class MathOperationsService : MathOperations.MathOperationsBase
{
    public override Task<AddReply> Add(AddRequest request, ServerCallContext context)
    {
        return Task.FromResult(new AddReply
        {
            Result = request.X + request.Y
        });
    }
    
    public override Task<SubtractReply> Subtract(SubtractRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SubtractReply
        {
            Result = request.X - request.Y
        });
    }
}