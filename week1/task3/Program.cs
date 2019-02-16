using System;

namespace task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());                                            //получить количество чисел
            int[] a = Array.ConvertAll<string, int>(Console.ReadLine().Split(), int.Parse);         //создадим массив 
            for (int i = 0; i < a.Length; i++)                                                      //вывод массив
            {
                Console.Write(a[i] + " " + a[i] + " ");                                             //дабл вывод
            }

        }
    }
}