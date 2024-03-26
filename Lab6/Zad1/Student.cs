using System;

namespace Program
{
    public class Student : IComparable<Student>
    {
        string imie;
        string nazwisko;
        public int numerIndeksu;
        public int rokStudiow;

        public Student(string imie, string nazwisko, int numerIndeksu, int rokStudiow)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.numerIndeksu = numerIndeksu;
            this.rokStudiow = rokStudiow;
        }

        public Student(Student student)
        {
            this.imie = student.imie;
            this.nazwisko = student.nazwisko;
            this.numerIndeksu = student.numerIndeksu;
            this.rokStudiow = student.rokStudiow;
        }

        public override string ToString()
        {
            return $" student {imie} {nazwisko} rok {rokStudiow} indeks numer: {numerIndeksu} ";
        }

        public override int GetHashCode()
        {
            return numerIndeksu;
        }

        public int CompareTo(Student? other)
        {
            if (other == null)
            {
                return 1;
            }

            return numerIndeksu.CompareTo(other.numerIndeksu);
        }

        public class StudentPoNazwiskuASCComparer : IComparer<Student>
        {
            public int Compare(Student? x, Student? y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return x.nazwisko.CompareTo(y.nazwisko);
            }
        }

        public class StudentPoRokStudiowDESCComparer : IComparer<Student>
        {
            public int Compare(Student? x, Student? y)
            {
                if (x == null || y == null)
                {
                    return 0;
                }

                return y.rokStudiow.CompareTo(x.rokStudiow);
            }
        }
    }
}