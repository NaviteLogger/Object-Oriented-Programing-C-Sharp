using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWarsUniverse {
    public enum StronaKonfiktu {
        REPUBLIKA,
        IMPERIUM
    }

    public class Planeta {
        public string nazwa;
        public uint? liczbaKsiezycow;

        public Planeta(string nazwa, uint? liczbaKsiezycow) {
            this.nazwa = nazwa;
            this.liczbaKsiezycow = liczbaKsiezycow;
        }

        public Planeta(Planeta planeta) : this(planeta.nazwa, planeta.liczbaKsiezycow) { }

        public override string ToString() {
            return $"Planeta {nazwa}, księżyce: {liczbaKsiezycow}";
        }
    }

    public class PostacStarWars {
        public string imie;
        public string gatunek;
        public string plec;
        public Planeta planetaMacierzysta;
        public StronaKonfiktu stronaKonfilktu;

        public PostacStarWars(string imie, string gatunek, string plec, Planeta planetaMacierzysta, StronaKonfiktu stronaKonfilktu) {
            this.imie = imie;
            this.gatunek = gatunek;
            this.plec = plec;
            this.planetaMacierzysta = planetaMacierzysta;
            this.stronaKonfilktu = stronaKonfilktu;
        }

        public PostacStarWars(PostacStarWars postac) : this(postac.imie, postac.gatunek, postac.plec, new Planeta(postac.planetaMacierzysta), postac.stronaKonfilktu) { }

        public override string ToString() {
            return $"Imie: {imie}, Gatunek: {gatunek}, Planeta Macierzysta: {planetaMacierzysta}, Plec: {plec}, Strona Konfilktu: {stronaKonfilktu}";
        }
    }

    public class PostacieStarWars {
        private List<PostacStarWars> postacie = new List<PostacStarWars>();

        public void Dodaj(PostacStarWars postac) {
            postacie.Add(postac);
        }

        [Obsolete("Ta metoda jest przestarzała! Użyj ZwrocPostaciPo(Wybierz wybierz, string wartosc)", false)]
        public List<PostacStarWars> ZwrocPostaciPoPlci(string plec) {
            return postacie.Where(p => p.plec == plec).ToList();
        }

        public List<PostacStarWars> ZwrocPostaciPo(Wybierz wybierz, string wartosc) {
            return postacie.Where(p => wybierz(p) == wartosc).ToList();
        }

        public override string ToString() {
            var sb = new StringBuilder();
            foreach (var postac in postacie) {
                sb.AppendLine(postac.ToString());
            }
            return sb.ToString();
        }
    }

    public delegate string Wybierz(PostacStarWars c);

    public static class ListExtension {
        public static string ZwrocInfoOLiscie<T>(this List<T> list) {
            var sb = new StringBuilder();
            foreach (var item in list) {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }

    class Program {
        static void Main(string[] args) {
            Planeta tatooine = new Planeta("Tatooine", 3);
            Planeta alderaan = new Planeta("Alderaan", 0);
            Planeta corellia = new Planeta("Corellia", null); //null ponieważ dane są rozbieżne w różnych źródłach
            Planeta stewjon = new Planeta("Stewjon", null); // brak informacji

            PostacStarWars anakin = new PostacStarWars("Anakin Skywalker ", "Czlowiek", "Mezczyzna", tatooine, StronaKonfiktu.REPUBLIKA);
            PostacStarWars leia = new PostacStarWars("Leia Organa", "Czlowiek", "Kobieta", alderaan, StronaKonfiktu.REPUBLIKA);
            PostacStarWars han = new PostacStarWars("Han Solo", "Czlowiek", "Mezczyzna", corellia, StronaKonfiktu.REPUBLIKA);
            PostacStarWars obiWan = new PostacStarWars("Obi-Wan Kenobi", "Czlowiek", "Mezczyzna", stewjon, StronaKonfiktu.REPUBLIKA);

            var postacie = new PostacieStarWars();
            postacie.Dodaj(anakin);
            postacie.Dodaj(leia);
            postacie.Dodaj(han);
            postacie.Dodaj(obiWan);

            // Step 2: Display information about characters using PostacieStarWars.ToString.
            Console.WriteLine(postacie);

            // Further steps involve modifying character and planet properties and displaying updated lists, demonstrating the application of OOP principles, method overloading, delegates, and extension methods in C#.
        }
    }
}
