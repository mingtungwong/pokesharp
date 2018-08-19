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
            PokemonAPIClient client = new PokemonAPIClient();
            Pokemon test = client.getPokemon("77");
            Console.WriteLine(test.Name);
            Console.WriteLine(test.Types[0]);
        }
    }
}
