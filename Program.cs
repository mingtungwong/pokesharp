using System;
using System.Net.Http;
using System.Text.RegularExpressions;
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
            Console.WriteLine("\nThanks for using the app!\n");
        }

        private static void showInstructions() {
            Console.WriteLine("\nThis console application calls the API at pokeapi.co to fetch Pokemon information.");
            Console.WriteLine("Enter a Pokemon ID number or name to get information for that Pokemon. Example: 8 or charmeleon.");
            Console.WriteLine("Enter 'e' or 'exit' to exit.\n");
        }

        private static void loop() {
            Console.Write("Enter your choice (ID or name, e or exit to close app): ");
            string choice = Console.ReadLine();
            // TODO: Handle empty strings.
            // Check for if input is command to exit application.
            if(choice == "e" || choice == "exit") {
                doLoop = false;
                return;
            }
            // Check if the input is a number, otherwise set the choice to lower case because
            // the API is case sensitive.
            choice = Regex.IsMatch(choice, @"^\d+$") ? choice : choice.ToLower(); 
            // Use the client class to grab the Pokemon.
            Pokemon p = client.getPokemon(choice);
            // Check if the Pokemon is null, null is returned in place of throwing an error.
            if(p == null) {
                Console.WriteLine("Sorry, there was an error fetching the Pokemon. Your entry might have been incorrect. Please try again.");
                return;
            } else {
                // If not null, call the Pokemon class' method to print information.
                p.printPokedexEntry();
            }
        }
    }
}
