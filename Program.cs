using System;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Sha256vsSha512
{
    public class Sha256vsSha512
    {
        private byte[] data;
        private SHA256 sha256 = SHA256.Create();
        private SHA512 sha512 = SHA512.Create();


        [Params(1000, 100000, 1000000, 10000000, 100000000)]
        public int N;


        [GlobalSetup]
        public void Setup()
        {
            data = new byte[N];
            new Random().NextBytes(data);
        }

        [Benchmark(Baseline = true)]
        public byte[] Sha256() => sha256.ComputeHash(data);

        [Benchmark]
        public byte[] Sha512() => sha512.ComputeHash(data);

    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Sha256vsSha512>();
        }
    }
}
