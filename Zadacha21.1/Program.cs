using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Zadacha21._1
{
    class Program
    {
        static int x = 5;
        static int y = 5;
        static int[,] garden = new int[x, y];
        public static void Gardener1()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (garden[i, j] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(100);
                }
            }
        }
        public static void Gardener2()
        {
            for (int i = y - 1; i > 0; i--)
            {
                for (int j = x - 1; j > 0; j--)
                {
                    if (garden[j, i] != 0)
                    {
                        continue;
                    }
                    else
                    {
                        garden[j, i] = 2;
                    }
                    Thread.Sleep(100);
                }
            }
        }
        static void Main(string[] args)
        {
            ThreadStart threadStart1 = new ThreadStart(Gardener1);
            Thread thread1 = new Thread(threadStart1);
            thread1.Start();

            ThreadStart threadStart2 = new ThreadStart(Gardener2);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();

            thread1.Join();
            thread2.Join();

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write("{0} ", garden[i, j]);
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
