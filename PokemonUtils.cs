using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace pokesharp {
    class PokemonUtils {

        public static Pokemon createPokemonObject(dynamic pokemonJson, dynamic pokemonSpeciesJson) {
            string name = capitalizeFirstLetter((string)pokemonJson.name);
            
            // Account for fact that weight and height are 10x larger
            decimal weight = pokemonJson.weight / 10.0M;
            decimal height = pokemonJson.height / 10.0M;
            
            List<dynamic> typesObj = getListFromJArray(pokemonJson.types);
            List<dynamic> flavorsObj = getListFromJArray(pokemonSpeciesJson["flavor_text_entries"]);
            string[] types = typesObj.Select(type => capitalizeFirstLetter((string)type.type.name)).Cast<string>().ToArray();
            string description = getDescription(flavorsObj);

            return new Pokemon(name, weight, height, types, description);
        }
        private static string getDescription(dynamic obj) {
            foreach (var textObj in obj) {
                if(textObj.language.name == "en") return textObj["flavor_text"];
            }
            return null;
        }

        private static List<dynamic> getListFromJArray(JArray arr) {
            return arr.ToObject<List<dynamic>>();
        }

        private static String capitalizeFirstLetter(string s) {
            if (string.IsNullOrEmpty(s)) return string.Empty;

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }
    }
}