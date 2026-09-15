using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    internal class Program
    {
        class Film
        {
            public Film(string nazev, string jmr, string pjmr, int rkvz, float hodn)
            {
                Nazev = nazev;
                Jmr = jmr;
                Pjmr = pjmr;
                Rkvz = rkvz;
                Hodn = hodn;
                hvezdocet = 1;
            }
            string Nazev;
            string Jmr;
            string Pjmr;
            int Rkvz;
            float Hodn;
            float hvezdocet;
            override public string ToString()
            {
                return $" Film: {Nazev}{Rkvz}{Pjmr}{Jmr[0]}{Hodn}";
            }
            public void dalsihodnoceni(float Novhodn)
            {
                Hodn = (((Hodn * hvezdocet) + Novhodn) / hvezdocet + 1);
                hvezdocet = hvezdocet + 1;
            }
        }
        static void Main(string[] args)
        {
            Film prvnifilm = new Film("Phoenician Scheme", "Wes", "Anderson", 2025, 4);
            Film druhyfilm = new Film("Mickey 17", "준호", "봉", 2025, 4);
            Film tretifilm = new Film("Disco Elysium", "Kurvitz", "Robert", 2019, 5);
            List<Film> list = new List<Film>() { prvnifilm, druhyfilm, tretifilm };

            foreach (Film film in list)
            {
                for (int i = 0; i < 15; i++)
                {
                    film.dalsihodnoceni(new Random().Next(0, 6));
                }
            }
            foreach (Film film in list)
            {
                Console.WriteLine(film.ToString());
                if (film.) 
                {
                }

            }

        }
    }
}