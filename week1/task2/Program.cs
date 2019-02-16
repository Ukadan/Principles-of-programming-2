using System;

namespace task2
{

    class Student
    {
        public string name;    //глобальная перемена под названием Name
        public int id;         //глобальная перемена под названием ID
        public int year;       //глобальная перемена под названием Year


        public Student(string name, int id)     //создаем конструктор с двумя переменнами
        {
            this.name = name;                   //даем значения
            this.id = id;                       
            this.year = 2018;                   
        }

        public void PrintInfo()                 //создаем функцию под названием PrintInfo 
        {
            Console.WriteLine("ID: " + id);         //вывод Id, Name, Year
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Year: " + year);
        }

        public void Year()                      //создадим функция Year 
        {
            year++;                             //прибавляем к значение year + 1
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Hacker", 777);  //даем значения
            s.Year();                                   //вызываем функцию
            s.PrintInfo();
        }
    }
}