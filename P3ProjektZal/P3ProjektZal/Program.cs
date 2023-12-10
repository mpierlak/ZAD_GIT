using P3ProjektZal;
using System.Collections.Generic;
using System.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P3ProjektZal
{
    class Program
{
    static void Main()
    {
        Console.WriteLine("Witaj! Podaj swoje imię:");
        string imieKlienta = Console.ReadLine();
        var słownik = new Słownik(@"C:\\Users\\marci\\OneDrive\\Pulpit\\P3ProjektZal\\słownik.txt");
        var zarządzanieKlientami = new ZarządzanieKlientami();

        var klient = new Klient(imieKlienta);
        zarządzanieKlientami.DodajKlienta(klient);

            do
            {
                Console.WriteLine($"Dzień dobry, {imieKlienta}. Jakie słowa chciałbyś przetłumaczyć? (Oddziel słowa przecinkiem)");
                string słowaDoTłumaczenia = Console.ReadLine();

                string[] słowaArray = słowaDoTłumaczenia.Split(',');

                File.AppendAllLines(@"C:\\Users\\marci\\OneDrive\\Pulpit\\P3ProjektZal\\tekstDoTłumaczenia.txt", słowaArray);

                TłumaczTekst(słowaArray, słownik, zarządzanieKlientami, klient);

                Console.WriteLine($"Przetłumaczono słowa. Wyniki zapisane w pliku przetłumaczonyTekst.txt.");

                

                var liczbaTłumaczeń = zarządzanieKlientami.IlośćTłumaczeńKlienta(klient);
                var średniaDługośćTekstu = zarządzanieKlientami.ŚredniaDługośćTekstuKlienta(klient);

                Console.WriteLine($"{klient.Imie}: Tłumaczenia: {liczbaTłumaczeń}, Średnia Długość Tekstu: {średniaDługośćTekstu}");

                Console.WriteLine("Czy chcesz złożyć kolejne zamówienie? (Tak/Nie)");
            } while (Console.ReadLine()?.ToLower() == "tak");


            Console.ReadLine();
    }

    static void TłumaczTekst(string[] słowa, Słownik słownik, ZarządzanieKlientami zarządzanieKlientami, Klient klient)
    {
        var przetłumaczoneSłowa = słowa.Select(słowo => słownik.Tłumacz(słowo) ?? słowo);

       
        var tłumaczenie = new Tłumaczenie(string.Join(", ", słowa), string.Join(", ", przetłumaczoneSłowa));
        zarządzanieKlientami.DodajTłumaczenie(tłumaczenie, klient);

       
        File.AppendAllLines(@"C:\\Users\\marci\\OneDrive\\Pulpit\\P3ProjektZal\\przetłumaczonyTekst.txt", przetłumaczoneSłowa);

        
        var liczbaTłumaczeń = zarządzanieKlientami.IlośćTłumaczeńKlienta(klient);
        var średniaDługośćTekstu = zarządzanieKlientami.ŚredniaDługośćTekstuKlienta(klient);

        
        File.AppendAllText(@"C:\\Users\\marci\\OneDrive\\Pulpit\\P3ProjektZal\\przetłumaczonyTekst.txt",
                            $"Liczba Tłumaczeń: {liczbaTłumaczeń}\nŚrednia Długość Tekstu: {średniaDługośćTekstu}\n");
    }
}

}
// brakuje dodawania nowych klientów, zapisywanie do pliku przerobić w taki sposób, by każdy użytkownik miał swój własny, odczyt pliku