using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using Newtonsoft.Json;

namespace CryptoStatistics.Services
{
    public static class ApiService
    {
        static readonly HttpClient client = new HttpClient();
        //static readonly string CoinApiKey = "e95ddad1-9164-4b48-9607-516bd1a99b5d";
        static readonly string TwitterApiKey = "";

        public static async Task<T> GetDataFromApiAsync<T>(string connectionString, Dictionary<string, string> query)
        {
            try
            {
                string response = await client.GetStringAsync($"{connectionString}?{Parser(query)}");
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message: {0} ", e.Message);
            }
            return default(T);
        }

        private static string Parser(Dictionary<string, string> query)
        {
            return string.Join("&", query.Select(x => $"{x.Key}={x.Value}").ToArray());
        }
    }
}