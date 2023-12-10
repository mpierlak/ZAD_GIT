using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ProjektZal
{
    public class Tłumaczenie
    {
        public string OryginalnyTekst 
        { 
            get;
        }

        public string PrzetłumaczonyTekst 
        { 
            get;
        }

        public Tłumaczenie(string oryginalnyTekst, string przetłumaczonyTekst)
        {
            OryginalnyTekst = oryginalnyTekst;
            PrzetłumaczonyTekst = przetłumaczonyTekst;
        }
    }
}

