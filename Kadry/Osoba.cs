using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadry
{
    class Adres
    {
        private string miejscowosc;
        private string kod;
        private string nazwaUlicy;
        private int numerDomu;
        private int? numerMieszkania;
        public string ZwrocMiejscowosc()
        {
            return miejscowosc;
        }
        public string ZwrocNazweUlicy()
        {
            return nazwaUlicy;
        }

        public string ZwrocKod()
        {
            return kod;
        }
        public int ZwrocNumerDomu()
        {
            return numerDomu;
        }
        public int? ZwrocNumerMieszkania()
        {
            return numerMieszkania;
        }

        public void ZmianAdres()
        {
            Console.WriteLine("Podaj nazwę miejscowości: ");
            miejscowosc = Console.ReadLine();

            Console.WriteLine("Podaj kod: ");
            kod = Console.ReadLine();

            Console.WriteLine("Podaj nazwę ulicy: ");
            nazwaUlicy = Console.ReadLine();

            do
            {
                Console.WriteLine("Podaj numer domu: ");
            } while (!int.TryParse(Console.ReadLine(), out numerDomu));

            Console.Write("Czy jest numer mieszkania? <t/n>: ");
            char c = Console.ReadKey().KeyChar;
            Console.WriteLine();
            if (c == 't')
            {
                int i;
                do
                {
                    Console.WriteLine("Podaj numer mieszkania: ");
                } while (!int.TryParse(Console.ReadLine(), out i));
                numerMieszkania = i;
            }
            else
            {
                numerMieszkania = null;
            }
        }
        public Adres(string miejscowosc, string kod, string nazwaUlicy, int numerDomu, int? numerMieszkania)
        {
            this.miejscowosc = miejscowosc;
            this.kod = kod;
            this.nazwaUlicy = nazwaUlicy;
            this.numerDomu = numerDomu;
            this.numerMieszkania = numerMieszkania;
        }

        public Adres(string nazwaUlicy, int numerDomu, int? numerMieszkania)
            :this("Warszawa","02-222",nazwaUlicy,numerDomu,numerMieszkania)
        {
        }

        public Adres(int numerDomu, int? numerMieszkania)
            : this("Aleje Jerozolimskie", numerDomu, numerMieszkania)
        {
        }

        public Adres(int numerDomu)
            : this(numerDomu, null)
        {
        }

        public Adres(Adres adres)
            :this(adres.miejscowosc,adres.kod,adres.nazwaUlicy,adres.numerDomu,adres.numerMieszkania)
        {
        }

        public string ZwrocInformacjeAdresowe()
        {
            return numerMieszkania != null ?
                string.Format("{0} {1} ul. {2} {3} m. {4}",
                kod, miejscowosc, nazwaUlicy, numerDomu, numerMieszkania) :
                string.Format("{0} {1} ul. {2} {3}",
                kod, miejscowosc, nazwaUlicy, numerDomu);
        }


    }
    class Osoba
    {
        private string nazwisko;
        private string imie;
        private int numerEwidencyjny;
        private Adres adresZamieszkania;

        public Osoba(string nazwisko, string imie, int numerEwidencyjny, Adres adresZamieszkania)
        {
            this.nazwisko = nazwisko;
            this.imie = imie;
            this.numerEwidencyjny = numerEwidencyjny;
            this.adresZamieszkania = new Adres(adresZamieszkania);
        }

        public Osoba(string nazwisko, string imie, int numerEwidencyjny, 
            string miejscowosc, string kod, string nazwaUlicy,
            int numerDomu, int? numerMieszkania)
            :this(nazwisko,imie,numerEwidencyjny,new Adres(miejscowosc,kod,nazwaUlicy,numerDomu,numerMieszkania))
        {       
        }

        public Osoba(string imie, int numerEwidencyjny, int numerDomu)
            :this("Kowalski",imie,numerEwidencyjny,"Warszawa", "02-222", "Aleje Jerozolimskie",numerDomu,null)
        {
        }

        public Osoba(Osoba osoba)
        {
            nazwisko = osoba.nazwisko;
            imie = osoba.imie;
            numerEwidencyjny = osoba.numerEwidencyjny;
            adresZamieszkania = new Adres(osoba.adresZamieszkania);

        }

        public string ZwrocInformacjeOsobowe()
        {
            return string.Format("pani(i) {0} {1} o numerze ewidencyjnym {2}" +
                " zamieszkały(a): {3}",
                imie, nazwisko, numerEwidencyjny, adresZamieszkania.ZwrocInformacjeAdresowe());
        }

        public Osoba Klonuj()
        {
            return (Osoba)this.MemberwiseClone();
        }

        public void ZmienDaneOsobowe()
        {
            Console.WriteLine("Podaj imie: ");
            imie = Console.ReadLine();
            Console.WriteLine("podaj nazwisko: ");
            nazwisko = Console.ReadLine();

            do
            {
                Console.WriteLine("Podaj numer ewidencyjny: ");
            } while (!int.TryParse(Console.ReadLine(), out numerEwidencyjny));

            adresZamieszkania.ZmianAdres();
        }
    }
}
