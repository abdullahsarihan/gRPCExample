using System;
using Grpc.Net.Client;
using grpcMessageClient;
using grpcServer;

namespace grpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("http://localhost:5287");

            var messageClient = new Message.MessageClient(channel);

            MessageResponse response = await messageClient.SendMessageAsync(new MessageRequest
            {
                Message = "Merhaba",
                Name = "Abdullah"
            });
            System.Console.WriteLine(response.Message);
            
            // var greetClient = new Greeter.GreeterClient(channel);

            // HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
            // {
            //     Name = "Abdullah'tan Selamlar"
            // });
            // System.Console.WriteLine(result.Message);
        }
    }
}