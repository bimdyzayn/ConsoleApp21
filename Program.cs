using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    class Program
    {
          private static int[,] plan;
          private static int b;
          private static int a;
          static void Main()
          {
              a = Convert.ToInt32(Console.ReadLine());
              b = Convert.ToInt32(Console.ReadLine());

              plan = new int[a, b];

              Thread sadovnik1 = new Thread(sad1);
              Thread sadovnik2 = new Thread(sad2);

            sadovnik1.Start();
            sadovnik2.Start();

            sadovnik1.Join();
            sadovnik1.Join();

              for (int i = 0; i < a; i++)
              {
                  for (int j = 0; j < b; j++)
                  {
                      Console.Write(plan[i, j] + " ");
                  }
                  Console.WriteLine();
              }

              Console.ReadLine();
          }

          private static void sad1()
          {
              for (int i = 0; i < a; i++)
              {
                  for (int j = 0; j < b; j++)
                  {
                      if (plan[i, j] == 0)
                          plan[i, j] = 1;
                      Thread.Sleep(10);
                  }
              }
          }

          private static void sad2()
          {
              for (int i = b - 1; i > 0; i--)
              {
                  for (int j = a - 1; j > 0; j--)
                  {
                      if (plan[j, i] == 0)
                          plan[j, i] = 2;
                      Thread.Sleep(10);
                  }
              }
          }
    }
}
