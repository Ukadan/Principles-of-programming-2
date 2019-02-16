using System.IO;

namespace task4
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string file = "input.txt.rtf";                                       // создаем файл input
            string path = @"/Users/ukadan.ali/Desktop/PP1/week2/task4/path/" + file; //путь к path
            string path1 = @"/Users/ukadan.ali/Desktop/PP1/week2/task4/path1/" + file; //путь к path1

            FileStream FS = new FileStream(path, FileMode.Create, FileAccess.Write);  //создаем в path файл input 
            FS.Close();                                                                 // закрываем окно FS
            File.Copy(path, path1);                                                   // копируем содержимое с path в path1
            File.Delete(path);                                                        // удаляем содержимое в path
        }
    }
}
