using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RonAndKanye
{
    class Program
    {
        static void Main(string[] args)
        {
            var ronSwanson = new HttpClient();

            var kanyeWest = new HttpClient();

            for (int i = 1; i <= 5; i++)
            {
                var ronResponse = ronSwanson.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                
                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                   
                var kanyeResponce = kanyeWest.GetStringAsync("https://api.kanye.rest").Result;
                   
                var kanyeQuote = JObject.Parse(kanyeResponce).GetValue("quote").ToString();
                    Console.WriteLine($"Ron said {ronQuote} \n" +
                    $"Kanye said \"{kanyeQuote}\" ");            
            }
            
        }
    }
}
