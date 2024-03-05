using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Valutak;

namespace ValutaValto
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Valuta> valutak = await ValutaAdatok();
            foreach (Valuta valuta in valutak)
            {
                Console.WriteLine($"{valuta.Base} - {valuta.Date}");
            }
            Console.WriteLine("Program vége!");
            Console.ReadLine();
        }

        private static async Task<List<Valuta>> ValutaAdatok()
        {
            List<Valuta> valutak = new List<Valuta>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://infojegyzet.hu/webszerkesztes/php/valuta/api/v1/arfolyam/");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                valutak.Add(Valuta.FromJson(jsonString));
            }
            return valutak;
        }
    }
}
