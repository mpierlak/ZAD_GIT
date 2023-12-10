using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace P3ProjektZal
{
    class ZarządzanieKlientami
    {
        private List<Tłumaczenie> tłumaczenia;
        private List<Klient> klienci;

        public ZarządzanieKlientami()
        {
            tłumaczenia = new List<Tłumaczenie>();
            klienci = new List<Klient>();
        }

        public void DodajKlienta(Klient klient)
        {
            klienci.Add(klient);
        }

        public void DodajTłumaczenie(Tłumaczenie tłumaczenie, Klient klient)
        {
            tłumaczenia.Add(tłumaczenie);

            // Sprawdzamy, czy klient już posiada to tłumaczenie
            if (!klient.PobierzTłumaczenia().Any(t => t.OryginalnyTekst == tłumaczenie.OryginalnyTekst && t.PrzetłumaczonyTekst == tłumaczenie.PrzetłumaczonyTekst))
            {
                klient.DodajTłumaczenie(tłumaczenie);
            }
        }

        public IEnumerable<Tłumaczenie> TłumaczeniaKlienta(Klient klient)
        {
            return klient.PobierzTłumaczenia();
        }

        public int IlośćTłumaczeńKlienta(Klient klient)
        {
            return TłumaczeniaKlienta(klient).Count();
        }

        public double ŚredniaDługośćTekstuKlienta(Klient klient)
        {
            var tłumaczeniaKlienta = TłumaczeniaKlienta(klient);
            if (tłumaczeniaKlienta.Any())
            {
                var wszystkieSłowa = tłumaczeniaKlienta.SelectMany(t => t.OryginalnyTekst.Split(',').Select(słowo => słowo.Trim()));
                return wszystkieSłowa.Average(słowo => słowo.Length);
            }
            return 0;
        }


        public List<Klient> Klienci => klienci;
    }

}