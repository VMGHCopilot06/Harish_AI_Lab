using System;
using System.Threading;

namespace APIMDemoAPI
{
    class DeadlockEx
    {
        private static readonly object lock1 = new object();
        private static readonly object lock2 = new object();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Thread1Method);
            Thread thread2 = new Thread(Thread2Method);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Threads completed execution.");
        }

        private static void Thread1Method()
        {
            lock (lock1)
            {
                Console.WriteLine("Thread 1 acquired lock1");
                Thread.Sleep(1000); // Simulate some work

                lock (lock2)
                {
                    Console.WriteLine("Thread 1 acquired lock2");
                }
            }
        }

        private static void Thread2Method()
        {
            // Ensure the same lock order as Thread1Method
            lock (lock1)
            {
                Console.WriteLine("Thread 2 acquired lock1");
                Thread.Sleep(1000); // Simulate some work

                lock (lock2)
                {
                    Console.WriteLine("Thread 2 acquired lock2");
                }
            }
        }
    }
}
