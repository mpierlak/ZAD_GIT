using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ProjektZal
{
     class Klient
    {
        public string Imie { get; }
        private List<Tłumaczenie> tłumaczenia;

        public Klient(string imie)
        {
            Imie = imie;
            tłumaczenia = new List<Tłumaczenie>();
        }

        public void DodajTłumaczenie(Tłumaczenie tłumaczenie)
        {
            tłumaczenia.Add(tłumaczenie);
        }

        public IEnumerable<Tłumaczenie> PobierzTłumaczenia()
        {
            return tłumaczenia;
        }
    }
}