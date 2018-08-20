using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace pokesharp {
    class PokemonUtils {

        public static Pokemon createPokemonObject(dynamic pokemonJson, dynamic pokemonSpeciesJson) {
            string name = capitalizeFirstLetter((string)pokemonJson.name);
            
            // Account for fact that weight and height are 10x larger.
            decimal weight = pokemonJson.weight / 10.0M;
            decimal height = pokemonJson.height / 10.0M;
            
            // Use helper method to change JArray to C# List objects.
            List<dynamic> typesObj = getListFromJArray(pokemonJson.types);
            List<dynamic> flavorsObj = getListFromJArray(pokemonSpeciesJson["flavor_text_entries"]);

            // Map over the List to capitalize first letter of each word and then cast the list and return as array.
            string[] types = typesObj.Select(type => capitalizeFirstLetter((string)type.type.name)).Cast<string>().ToArray();
            // Helper method call to get description.
            string description = getDescription(flavorsObj);

            return new Pokemon(name, weight, height, types, description);
        }
        private static string getDescription(dynamic obj) {
            // Check each entry in obj to see if the language that the flavor text
            // is English and returns the first English entry found. Returns null
            // if not found.
            foreach (var textObj in obj) {
                if(textObj.language.name == "en") return textObj["flavor_text"];
            }
            return null;
        }
        
        // Simple helper method.
        private static List<dynamic> getListFromJArray(JArray arr) {
            return arr.ToObject<List<dynamic>>();
        }

        // Simple method to capitalize first letter of word.
        private static String capitalizeFirstLetter(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}