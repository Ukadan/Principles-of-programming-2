using System;
using System.IO;


namespace task1
{
    class Program
    {
        public static bool CheckPrime(int x)                                   // функция для проверки число на прайм
        {
            if (x == 1)                                                        // проверяем с начало что это число равен ли к единице
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(x); i++)                            //массив для проверки на прайм
            {
                if (x % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"/Users/ukadan.ali/Desktop/PP1/week2/task2/input.txt", FileMode.Open, FileAccess.Read);  //готовим файл 

            StreamReader sr = new StreamReader(fs); // читаем файл в fs 
            string s = sr.ReadLine();               // кидаем прочитанный числа в s
            FileStream fss = new FileStream(@"/Users/ukadan.ali/Desktop/PP1/week2/task2/ouput.txt", FileMode.Create, FileAccess.Write); // готовим файл
            StreamWriter sw = new StreamWriter(fss);  //готовим
            sr.Close();                                 //закрываем файл sr когда уже прочитали
            string[] a = s.Split();                     // читаем числа исключая пробел (Split());
            for (int i = 0; i < a.Length; i++)          // массив для вывода и проверки 
            {
                if (CheckPrime(int.Parse(a[i])) == true)     //с начала делаем число конверт в ToInt32 потом проверяем это на прайм
                    sw.Write(a[i] + " ");                    // если прайм подвердилось кидаем эти числа в ouput файл

            }
            sw.Close();                                  // после проверки всех праймов закрываем sw



        }
    }
}