using System;
using System.IO;

namespace task3
{
    class Program
    {
        public static int[] Double(int[] a)                                     //создаем функцию Double
        {
            int[] x = new int[a.Length * 2];                                    //даем для массива x двойной размер чем массив а
            for (int i = 0; i < a.Length; i++)
            {
                x[2 * i] = a[i];                                                //делаем double чисел и кидаем числа в соседние позиций
                x[2 * i + 1] = a[i];
            }

            return x;
        }
        static void Main(string[] args)
        {
          
            int n = int.Parse(Console.ReadLine());                              //читаем длинну массива
            string[] s = Console.ReadLine().Split();                            //читаем числа
            int[] a = new int[n];                                               //создаем массив
            for (int i = 0; i < n; i++)                                         //создали массив для того чтобы перекинуть все числа с s в массив
            {
                a[i] = int.Parse(s[i]);                                         //кидаем в массив
            }

            int[] x = Double(a);                                                //кидаем в массив х все значение с функций Double
                        for (int i = 0; i < x.Length; i++)
            {
                Console.Write(x[i] + " ");
            }
        }
       
       
    }
}