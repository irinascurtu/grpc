using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace MyFirstGrpc.Services
{
    public class FibonacciService : Fibo.FiboBase
    {
        public override Task<FibonacciResult> ComputeFibonacci(RequestedNumber request, ServerCallContext context)
        {
            int n = request.Number;

            return Task.FromResult(new FibonacciResult
            {
                Result = Fibonacci(n)
            });
        }

        private static int Fibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

    }
}
