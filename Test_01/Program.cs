using System;
using System.Threading;

using Project.Business.Watch;

namespace Project.Testing.Test_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Watch W = new();

            Console.WriteLine("Start...");


            W.Start();

            Thread.Sleep(10000);

            Console.WriteLine("Miliseconds: " + W.Stopwatch.ElapsedMilliseconds);

            W.Stop();
            
        }
    }
}
