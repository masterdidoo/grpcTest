using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Utils;
using RenCapGrpc.Shared;

namespace RenCapGrpc.Client
{
    public class Program
    {
        private static Channel channel;

        public static void Main(string[] args)
        {
            channel = new Channel("127.0.0.1", 5000, ChannelCredentials.Insecure);

            Run(1);
            RunAsync(2).Wait();
            Run(3);


            channel.ShutdownAsync();
        }

        private static void Run(int i)
        {
            var invoker = new DefaultCallInvoker(channel);
            {
                var response = invoker.BlockingUnaryCall(Descriptors.Method, null, new CallOptions { }, new CustomRequest { Payload = i });

                Console.WriteLine($"{i} Got sync response: {response.Payload}");
            }

            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();
        }

        private static async Task RunAsync(int i)
        {
            var invoker = new DefaultCallInvoker(channel);
            using (var call = invoker.AsyncUnaryCall(Descriptors.Method, null, new CallOptions{}, new CustomRequest { Payload = i }))
            {
                var response = await call.ResponseAsync;

                Console.WriteLine($"{2} Got async response: {response.Payload}");
            }

            Console.WriteLine("Press enter to stop...");
            Console.ReadLine();
        }
    }
}