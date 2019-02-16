using System;
using System.IO;
using System.Collections.Generic;

namespace task1
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());                                            //читаем длинну массива
            int[] a = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);         //создаем массив
            int NoP = 0;                                                                            //создадим счетчик

            List<int> Prime = new List<int>();                                                      //создаем List для прайм чисел

            for (int i = 0; i < a.Length; i++)                                                      //массив для нахождения прайм чисел
            {
                if (CheckPrime(a[i]))                                                               //вызываем функцию CheckPrime для проверки чисел
                {
                    Prime.Add(a[i]);                                                                //все числа которые прайм мы кидаем в list                      
                    NoP++;                                                                          //увеличиваем счетчик каждый раз когда мы находим число прайм
                }
            }
            Console.WriteLine(NoP);                                                                 //выводим количество прайм чисел
            foreach (int el in Prime)                                                               //через массив выводим прайм числы                                                            

                Console.Write(el + " ");                                                            //вывод через пробел
        }


        static bool CheckPrime(int x)                                                               //функция для проверки число на прайм
        {
            if (x == 1)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(x); i++)
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
    }

