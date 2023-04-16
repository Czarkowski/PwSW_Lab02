using System;
using System.Collections.Generic;
using System.Text;

using Osoba;

namespace Drzewa
{
    public class Drzewo
    {
        class Wezel
        {
            public Osoba.Osoba Dane;
            public Wezel Lewy=null, Prawy=null;

            public Wezel()
            {
                this.Dane = new Osoba.Osoba();
            }
            public Wezel(Osoba.Osoba osoba)
            {
                this.Dane = osoba;
            }
            public Wezel(string imie, string nazwisko, int rok, byte miesiec, byte dzien)
            {
                this.Dane = new Osoba.Osoba(imie,nazwisko, rok, miesiec, dzien);
            }
            public void KlonujRekurencyjnie(Wezel wezel)
            {
                wezel.Dane = new Osoba.Osoba(Dane);
                if (Lewy != null)
                {
                    wezel.Lewy = new Wezel();
                    Lewy.KlonujRekurencyjnie(wezel.Lewy);
                }
                if (Prawy != null)
                {
                    wezel.Prawy = new Wezel();
                    Prawy.KlonujRekurencyjnie(wezel.Prawy);
                }
            }

            public void KlonujReferencje(Wezel wezel)
            {
                wezel.Dane = Dane;
                if (Lewy != null)
                {
                    wezel.Lewy = new Wezel();
                    Lewy.KlonujReferencje(wezel.Lewy);
                }
                if (Prawy != null)
                {
                    wezel.Prawy = new Wezel();
                    Prawy.KlonujReferencje(wezel.Prawy);
                }
            }


            public void WypiszWezel()
            {
                if (Lewy != null)
                    Lewy.WypiszWezel();
                Dane.WypiszOsobe();
                Console.WriteLine();
                if (Prawy != null)
                    Prawy.WypiszWezel();
            }
        
        }
        private Wezel korzen = null;

        public Drzewo()
        {

        }

        public Drzewo(string imie, string nazwisko, int rok, byte miesiec, byte dzien)
        {
            this.korzen = new Wezel( new Osoba.Osoba(imie, nazwisko, rok, miesiec, dzien));
        }

        public Drzewo(Osoba.Osoba[] osoby)
        {
            for (int i = 0; i < osoby.Length; i++)
            {
                DodajElement(osoby[i]);
            }
        }

        public Drzewo KlonujRekurencyjnie()
        {
            Drzewo nowa = new Drzewo();
            if (korzen != null)
            {
                nowa.korzen = new Wezel();           
                korzen.KlonujRekurencyjnie(nowa.korzen);             
            }
            return nowa;
        }
        public Drzewo KlonujReferencje()
        {
            Drzewo nowa = new Drzewo();
            if (korzen != null)
            {
                nowa.korzen = new Wezel();
                korzen.KlonujReferencje(nowa.korzen);
            }
            return nowa;
        }
        public Drzewo Klonuj()
        {
            return (Drzewo)this.MemberwiseClone();
        }
        public bool CzyPuste()
        {
            return korzen == null;
        }

        public void DodajElement(Osoba.Osoba osoba)
        {
            if(korzen == null)
            {
                korzen = new Wezel();
                korzen.Dane = osoba;
                return ;
            }
            Wezel p = korzen, poprzedni;
            do{
                poprzedni = p;
                if(osoba.CompareTo(p.Dane )<0)
                    p = p.Lewy;
                else
                    p = p.Prawy;
            }
            while(p != null);
            if (osoba.CompareTo(poprzedni.Dane) < 0)
            {
                poprzedni.Lewy = new Wezel();
                poprzedni.Lewy.Dane = osoba;
            }
            else
            {
                poprzedni.Prawy = new Wezel();
                poprzedni.Prawy.Dane = osoba;
            }
        }   

        

        public void PrintAll()
        {
            if (korzen != null)
                korzen.WypiszWezel();
        }

        

 
    }

}
