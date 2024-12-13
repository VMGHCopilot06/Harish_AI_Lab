using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<byte[]> memoryLeakList = new List<byte[]>();

        for (int i = 0; i < 10000; i++)
        {
            // Allocate 1 MB of memory
            byte[] buffer = new byte[1024 * 1024];
            memoryLeakList.Add(buffer);

            // Simulate some processing
            Console.WriteLine($"Iteration {i}");
        }

        Console.WriteLine("Done");
    }
}