using System;

namespace Kadry
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba os1 = new Osoba("Nowak", "Jan", 1, "Piotrków Tryb", "97-300", "Kwiatowa", 23, 12);
            Osoba klon1 = os1.Klonuj();
            Console.WriteLine("Oryginał {0}",os1.ZwrocInformacjeOsobowe());
            Console.WriteLine("Klon {0}",klon1.ZwrocInformacjeOsobowe());
            Console.WriteLine("\n***Zmieniamy klona:***\n");
            klon1.ZmienDaneOsobowe();
            Console.WriteLine("Oryginał {0}",os1.ZwrocInformacjeOsobowe());
            Console.WriteLine("Klon {0}",klon1.ZwrocInformacjeOsobowe());

            Console.WriteLine("\n***Kopiowanie głębokie***\n");

            Adres adr = new Adres(13);
            Osoba os2 = new Osoba("Wiśniewski", "Jacek", 10, adr);
            Osoba klon2 = new Osoba(os2);
            Console.WriteLine("Oryginał drugi {0}", os2.ZwrocInformacjeOsobowe());
            Console.WriteLine("Klon drugi {0}", klon2.ZwrocInformacjeOsobowe());
            Console.WriteLine("\n***Zmieniamy drugiego klona:***\n");
            klon2.ZmienDaneOsobowe();
            Console.WriteLine("Oryginał drugi {0}", os2.ZwrocInformacjeOsobowe());
            Console.WriteLine("Klon drugi {0}", klon2.ZwrocInformacjeOsobowe());

            Console.ReadKey();

            //Adres adr2 = new Adres();
        }
    }
}
