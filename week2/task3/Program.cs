using System;
using System.IO;

namespace task3
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string path = Console.ReadLine();
            DirectoryInfo file = new DirectoryInfo(path);
            PrintInfo(file, 0);
        }

        private static void PrintInfo(FileSystemInfo file, int k)               // создаем фукнкцию под название PrintInfo
        {
            if (file.GetType() == typeof(DirectoryInfo))                        // проверяем обьект на папку
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;                 // если это папка то красим его в черный в красный цвет 
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;                  // если это файл то красим его в желтый
            }
            Console.WriteLine(new string(' ', k) + file.Name);                  //выводим через определенный количество пробела название файла
            if (file.GetType() == typeof(DirectoryInfo))
            {
                FileSystemInfo[] arr = ((DirectoryInfo)file).GetFileSystemInfos(); //кидаем все в массив
                foreach (FileSystemInfo a in arr)                                  //массив для вывода 
                {
                    PrintInfo(a, k + 3); // вызовая фукнцию PrinInfo кидаем туда обьект который с начала проверяется на папку и файл потом красим в цвет и выводим через 3 пробела каждую папку
                }
            }
        }
    }
}