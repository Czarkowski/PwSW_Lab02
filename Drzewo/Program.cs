using System;
using Drzewa;
using Osoba;

namespace TestDrzewa
{
    class Program
    {
        static void Main(string[] args)
        {
            Osoba.Osoba[] osoby = new Osoba.Osoba[3];
            osoby[0] = (new Osoba.Osoba());
            osoby[1] = (new Osoba.Osoba("Adam","Podpałka",1995,10,1));
            osoby[2] = (new Osoba.Osoba("Martyna","Zapałka",1997,11,12));

            Drzewo drzewo = new Drzewo(osoby);
            Console.WriteLine("Oryginalne drzewo: ");
            drzewo.PrintAll();
            Console.WriteLine("Tworzymy trzy rodzaje kopi.");
            Drzewo drzewoKopiaRekurencja = drzewo.KlonujRekurencyjnie();
            Drzewo drzewoKopiaReferencja = drzewo.KlonujReferencje();
            Drzewo drzewoKlon = drzewo.Klonuj();

            Console.WriteLine("Zmiana osoby w Oryginale: ");
            osoby[0].WprowadzOsobe();
            Console.WriteLine("Dodanie osoby do Kopi płytkiej: ");
            drzewoKlon.DodajElement(new Osoba.Osoba()); 
            

            Console.WriteLine("Po zmianie: ");
            Console.WriteLine("\nOryginał: ");
            drzewo.PrintAll();
            Console.WriteLine("\nKopia przez Referencję: ");
            drzewoKopiaReferencja.PrintAll();
            Console.WriteLine("\nKopia Głęboka: ");
            drzewoKopiaRekurencja.PrintAll();
            Console.WriteLine("\nKopia płytka: ");
            drzewoKlon.PrintAll();

        }
    }
}
