using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Utils;
using RenCapGrpc.Shared;

namespace RenCapGrpc.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        private static async Task RunAsync()
        {
            var server = new Grpc.Core.Server
            {
                Ports = {{"127.0.0.1", 5000, ServerCredentials.Insecure}},
                Services =
                {
                    ServerServiceDefinition.CreateBuilder()
                    //.AddMethod(Descriptors.Method, Call)
                    //.AddMethod(Descriptors.Method, (request, context)=>{
                    //    return Task.FromResult(new CustomResponse { Payload = request.Payload + 10000 });
                    //})
                        .AddMethod(Descriptors.Method, async (requestStream, responseStream, context) =>
                        {
                            await requestStream.ForEachAsync(async request =>
                            {
                                // handle incoming request
                                // push response into stream
                                await responseStream.WriteAsync(new CustomResponse {Payload = request.Payload+10000});
                            });
                        })
                        .Build()
                }
            };

            server.Start();

            Console.WriteLine($"Server started under [127.0.0.1:5000]. Press Enter to stop it...");
            Console.ReadLine();

            await server.ShutdownAsync();
        }

        private static async Task<CustomResponse> Call(CustomRequest request, ServerCallContext context)
        {
            return new CustomResponse { Payload = request.Payload + 10000 };
        }
    }
}