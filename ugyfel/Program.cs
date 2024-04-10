using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ugyfel
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            List<Tagdij> tagdij = new List<Tagdij>();
            tagdij = await ugyfelKarbantartas();
            Console.WriteLine($"Összes ügyel: {tagdij}");
            Tagdij maxpaid = null;
            foreach (Tagdij tagdijas in tagdij)
            {
                if(maxpaid == null || tagdijas.Azon > maxpaid.Azon)
                {
                    maxpaid = tagdijas;
                }
            }
        }
        private static async Task<List<Tagdij>> ugyfelKarbantartas()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost/tagdijvizsgaszeru/index.php?ugyfelkarban");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
    }
}
