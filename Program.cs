using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pokesharp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
            int pokemonId = 58;
            HttpResponseMessage response = client.GetAsync($"pokemon/{pokemonId}").Result;
            HttpResponseMessage response2 = client.GetAsync($"pokemon-species/{pokemonId}").Result;
            if(response.IsSuccessStatusCode && response2.IsSuccessStatusCode) {
                string respString = response.Content.ReadAsStringAsync().Result;
                string respString2 = response2.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject<object>(respString);
                dynamic json2 = JsonConvert.DeserializeObject<object>(respString2);
                Pokemon p = PokemonUtils.createPokemonObject(json, json2);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Description);
            } else Console.WriteLine("I got an error");
        }
    }
}
