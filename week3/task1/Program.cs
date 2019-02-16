using System;
using System.IO;

namespace FarManager
{
    class FarManager ///Users/ukadan.ali/Desktop/midka
    {
        public int cursor;                                                  //объявление глобальных переменных класса, курсор для указания строк
        public int size;                                                    //размер каталога
        public string path;                                                 //строковый путь к главному каталогу



        public FarManager(string path)                                       //конструктор для создания нового объекта класса
        {
            this.path = path;                                               //параметр для пути строки
            cursor = 0;                                                     //установка курсора на нулевую линию
            DirectoryInfo directory = new DirectoryInfo(path);              //указание каталога для управления
            size = directory.GetFileSystemInfos().Length;                   //количество файлов и каталогов в главном каталоге
        }




        public void Up()                                                     //метод замены курсора вверх
        {
            cursor--;
            if (cursor < 0)
                cursor = size - 1;
        }



        public void Down()                                                 //метод замены курсора вниз
        {
            cursor++;
            if (cursor == size)
                cursor = 0;
        }

        public void Color(FileSystemInfo fs, int index)                     //способ определения каталогов и файлов с цветом
        {


            if (index == cursor)                                            //цвет курсора
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = ConsoleColor.Black;
            }


            else if (fs.GetType() == typeof(FileInfo))                   //файлы будут представлены желтым цветом
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }


            else                                                         //каталоги будут представлены белым цветом
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Show()                                                   //метод печати подкаталогов и файлов в каталоге
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.SetCursorPosition(6, 0);
            Console.WriteLine(path);                                         //добавление заголовка с путем к строке каталога
            Console.WriteLine();
            DirectoryInfo directory = new DirectoryInfo(path);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();            //получение всех файлов и каталогов
            size = fs.Length;                                                //получение их общего количества
            for (int i = 0; i < fs.Length; i++)                              //запуск через каждый файл и папку
            {
                Color(fs[i], i);                                             //раскраска их
                Console.WriteLine(i + 1 + ". " + fs[i].Name);                //печать их и добавление номера заказа к каждой строке
            }
        }

        public void Start()                                                  //функция для управления каталогом
        {
            DirectoryInfo directory = new DirectoryInfo(path);               //получение информации о конкретном каталоге
            ConsoleKeyInfo consoleKey = Console.ReadKey();                   //добавление переменной для работы с клавиатурой
            FileSystemInfo fs = null;                                        //пустая файловая система
            while (true)                                                     //бесконечный цикл
            {
                Show();                                                      //печать файлов и каталогов главного каталога
                consoleKey = Console.ReadKey();                              //чтение ключей
                int k = 0;
                for (int i = 0; i < directory.GetFileSystemInfos().Length; i++)//запуск через Главный каталог
                {
                    if (cursor == k)
                    {
                        fs = directory.GetFileSystemInfos()[i];                //назначение файла или каталога FS, в котором находится курсор
                        break;
                    }
                    k++;
                }
                if (consoleKey.Key == ConsoleKey.Escape)                       //нажмите Escape, чтобы вернуться в родительскую папку
                {
                    cursor = 0;
                    directory = directory.Parent;
                    path = directory.FullName;
                }
                if (consoleKey.Key == ConsoleKey.UpArrow)                      //нажатие стрелки вверх для перемещения курсора вверх
                    Up();
                if (consoleKey.Key == ConsoleKey.DownArrow)                    //нажатие стрелки вниз для перемещения курсора вниз
                    Down();
                if (consoleKey.Key == ConsoleKey.Enter)                        //нажмите Enter, чтобы открыть каталог или текстовый файл
                {
                    if (fs.GetType() == typeof(DirectoryInfo))                 //кейс для каталога
                    {
                        cursor = 0;
                        directory = new DirectoryInfo(fs.FullName);
                        path = fs.FullName;
                    }
                    if (fs.GetType() == typeof(FileInfo))                      //кейс для файла (открытие txt файла)
                    {
                        Console.BackgroundColor = ConsoleColor.White;          //окрашивание консоли в белый цвет
                        Console.ForegroundColor = ConsoleColor.Black;          //печать текста черным цветом
                        Console.Clear();
                        StreamReader sr = new StreamReader(fs.FullName);       //открытие файла
                        string s = sr.ReadToEnd();                             //чтение всего текста
                        Console.WriteLine(s);                                  //печать
                        sr.Close();                                            //закрытие потока
                        Console.ReadKey();
                    }
                }
                if (consoleKey.Key == ConsoleKey.D)                       //нажатие клавиши D to для удаления файлов и каталогов
                {
                    if (fs.GetType() == typeof(FileInfo))                      //проверка файла
                        File.Delete(fs.FullName);                              //удаление файла
                    else if (fs.GetType() == typeof(DirectoryInfo))            //проверка каталога
                        Directory.Delete(fs.FullName, true);                   //удаление каталога
                }
                if (consoleKey.Key == ConsoleKey.R)                           //нажатие клавиши R для переименования файлов и каталогов
                {
                    if (fs.GetType() == typeof(FileInfo))                      //проверка файла
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;           //окраска консоли в серый цвет
                        Console.Clear(); //clearing it
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Напишите новое имя для файла:");
                        string newFileName = Console.ReadLine();               //чтение нового имени файла
                        string sourceFile = fs.FullName;                       //объявление исходного пути
                        string destFile = path + "/" + newFileName;            //объявление целевого пути
                        File.Move(sourceFile, destFile);                       //перемещение файла в том же каталоге, но с новым именем
                    }
                    if (fs.GetType() == typeof(DirectoryInfo))                 //проверка каталога
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;           //окраска консоли в серый цвет
                        Console.Clear();                                       //очищая ее
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Напишете новое название обьекта:");
                        string newDirectoryName = Console.ReadLine();          //чтение нового имени каталога
                        string sourceDirectory = fs.FullName;                  //объявление исходного пути
                        string destDirectory = path + "/" + newDirectoryName;  //объявление целевого пути
                        Directory.Move(sourceDirectory, destDirectory);        //перемещение каталога в том же родительском каталоге, но с новым именем
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"/Users/ukadan.ali/Desktop/midka";                  //объявление пути строки для работы с
            FarManager farManager = new FarManager(path);                      //создание нового объекта в классе
            farManager.Show();                                                 //печать файлов, каталогов и заголовков
            farManager.Start();                                                //вызов главной функции для управления каталогами
        }
    }
}
