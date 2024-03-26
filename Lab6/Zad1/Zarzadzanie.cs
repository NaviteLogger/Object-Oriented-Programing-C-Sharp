using System;
using System.Text;
using System.Collections.Generic;

namespace Program
{
    public delegate void Akcja<T>(T t);

    class Zarzadzanie<T> where T : IComparable<T>
    {
        List<T> zarzadzani;

        public Zarzadzanie(List<T> zarzadzani)
        {
            this.zarzadzani = zarzadzani;
        }

        public int? PodajPozycje(T t)
        {

            for (int i = 0; i < zarzadzani.Count; i++)
            {
                if (zarzadzani[i].Equals(t))
                {
                    return i;
                }
            }

            throw new ZarzadzanieException("Przekazano do metody PodajPozycje null!");
        }

        public void Sortuj()
        {
            try
            {
                zarzadzani.Sort();
            }
            catch
            {
                throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!");
            }
        }

        public void Sortuj<U>(U u)
        {
            try
            {
                zarzadzani.Sort((IComparer<T>?)u);
            }
            catch
            {
                throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!");
            }
        }

        public void Modyfikuj(Akcja<T> akcja)
        {
            foreach (var item in zarzadzani)
            {
                akcja(item);
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("Zarzadzani: ");
            foreach (var item in zarzadzani)
            {
                str.Append("\t" + item.ToString());
            }

            return str.ToString();
        }

        class ZarzadzanieException : Exception
        {
            public ZarzadzanieException(string message) : base(message)
            {
                Console.WriteLine("${message}");
            }
        }
    }
}