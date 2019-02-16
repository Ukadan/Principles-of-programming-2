using System;
using System.IO;

namespace task1
{
    class MainClass
    {
        public static bool CheckPolindrom(string text)                          // функция для проверки на полиндром
        {
            for (int i = 0; i < text.Length / 2; i++)                          // массив который начинается с начала до середины 
                if (text[i] != text[text.Length - i - 1])                      //проверяем на не сходство букв на противоположном позиций
                    return false;

            return true;
        }
        public static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"/Users/ukadan.ali/Desktop/PP1/week2/task1/pal.txt", FileMode.Open, FileAccess.Read); //готовить файл для работы и одобряем для чтение файла и открытие
            StreamReader sr = new StreamReader(fs);                             //читает файл в fs

            string text = sr.ReadLine();                                        // кидаем в text прочитанный нами для его использование 



            if (CheckPolindrom(text))                                           //проверяем если текст на палиндром
                Console.WriteLine("Yes");                                       //если палиндром подвердлилось то говорим да

            else
                Console.WriteLine("No");                                       //если не палиндром подвердлилось то говорим нет
        }



    }


}
