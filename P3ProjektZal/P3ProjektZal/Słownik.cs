using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P3ProjektZal
{
     public class Słownik
    {
        private List<Słowo> słowa;

        public Słownik(string słownikścieżkapliku)
        {
            słowa = File.ReadAllLines(słownikścieżkapliku)
                .Select(line => line.Split(','))
                .Select(parts => new Słowo { PolskieSłowo = parts[0], AngielskieSłowo = parts[1] })
                .ToList();
        }

        public string Tłumacz(string słowo)
        {
            var TłumaczoneSłowo = słowa.FirstOrDefault(w => w.PolskieSłowo == słowo)?.AngielskieSłowo;
            if (TłumaczoneSłowo == null)
            {
                BłądTłumaczenia(słowo);
            }
            return TłumaczoneSłowo;
        }

        public event Action<string> błądtłumaczenia;

        protected virtual void BłądTłumaczenia(string słowo)
        {
            błądtłumaczenia?.Invoke($"Błąd: {słowo} nie ma w słowniku");
        }
    }

}
