using System;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new Student("Jan", "Kowalski", 12345, 2);

            Student student2 = new Student("Anna", "Nowak", 23456, 1);

            Student student3 = new Student("Piotr", "Lewandowski", 34567, 4);

            Student student4 = new Student("Alicja", "Dąbrowska", 45678, 2);

            Student student5 = new Student("Kamil", "Mazurek", 56789, 1);

            List<Student> listaStudentow =
            [
                new Student(student1),
                new Student(student2),
                new Student(student3),
                new Student(student4),
                new Student(student5),
            ];

            Zarzadzanie<Student> zarzadzanieStudentami = new Zarzadzanie<Student>(listaStudentow);

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");

            student1.numerIndeksu = 123456;

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");

            zarzadzanieStudentami.Sortuj();

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");

            zarzadzanieStudentami.Sortuj<Student.StudentPoNazwiskuASCComparer>(new Student.StudentPoNazwiskuASCComparer());

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");

            zarzadzanieStudentami.Sortuj<Student.StudentPoRokStudiowDESCComparer>(new Student.StudentPoRokStudiowDESCComparer());

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");

            zarzadzanieStudentami.Modyfikuj((student) => student.rokStudiow++);

            Console.WriteLine(zarzadzanieStudentami.ToString());
            Console.WriteLine("");
        }
    }
}