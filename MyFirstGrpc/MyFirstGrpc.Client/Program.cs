using System;
using Grpc.Core;

namespace MyFirstGrpc.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Fibo.FiboClient(channel);
            while (true)
            {
                String number = Console.ReadLine();
                int n = Int32.Parse(number);
                var reply = client.ComputeFibonacci(new RequestedNumber { Number = n });
                Console.WriteLine($"Fibonacci for {n} is:{reply.Result}");
            }
        }
    }
}
