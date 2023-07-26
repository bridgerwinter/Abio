using System;
using System.Diagnostics;

namespace AbioShell
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var process1 = new Process())
            {
                process1.StartInfo.FileName = @"..\..\..\Abio.Console.Application\bin\Debug\ConsoleApp1.exe";
                process1.Start();
            }

            using (var process2 = new Process())
            {
                process2.StartInfo.FileName = @"..\..\..\Abio.WS\bin\Debug\ConsoleApp2.exe";
                process2.Start();
            }
        }
    }
}