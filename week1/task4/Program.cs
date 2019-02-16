using System;

namespace task4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());                        //читаем число
            for (int i = 1; i <= n; i++)                                  //массив которые  идет вертикально     
            {
                for (int j = 1; j <= i; j++)                              //массив которые идет горизонтально
                {
                    Console.Write("[*]");                                 //вывод количество символов [*] которые выдает массив                                 
                }
                Console.WriteLine();                                      //начать с новой линий
            }
        }
    }
}
