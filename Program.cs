using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace pokesharp
{
    class Program
    {
        private static PokemonAPIClient client = new PokemonAPIClient();
        private static bool doLoop = true;
        static void Main(string[] args)
        {
            showInstructions();
            while(doLoop) {
                loop();
            }
            Console.WriteLine("Thanks for using the app!");
        }

        private static void showInstructions() {
            Console.WriteLine("This console application calls the API at pokeapi.co to fetch Pokemon information.");
            Console.WriteLine("Enter a Pokemon ID number or name to get information for that Pokemon. Example: 8 or charmeleon.");
            Console.WriteLine("Enter 'e' or 'exit' to exit.");
        }

        private static void loop() {
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            if(choice == "e" || choice == "exit") {
                doLoop = false;
                return;
            }
            Pokemon p = client.getPokemon(choice);
            if(p == null) {
                Console.WriteLine("Sorry, there was an error fetching the Pokemon. Your entry might have been incorrect. Please try again.");
                return;
            } else {
                p.printPokedexEntry();
            }
        }
    }
}
