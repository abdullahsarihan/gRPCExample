using Grpc.Core;
using grpcMessageServer;
using grpcServer;

namespace grpcServer.Services;

public class MessageService : Message.MessageBase
{
    public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageResponse> responseStream, ServerCallContext context)
    {
        System.Console.WriteLine($"Message : {request.Message} | Name : {request.Name}");

        for (int i = 0; i < 10; i++)
        {
            await Task.Delay(1000);
            await responseStream.WriteAsync(new MessageResponse
            {
                Message = "Merhaba " + i
            });
        }
    }
}