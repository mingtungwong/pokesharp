using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace pokesharp {
    class PokemonUtils {

        public static Pokemon createPokemonObject(dynamic pokemonJson, dynamic pokemonSpeciesJson) {
            string name = pokemonJson.name;
            decimal weight = pokemonJson.weight;
            decimal height = pokemonJson.height;
            List<dynamic> typesObj = getListFromJArray(pokemonJson.types);
            List<dynamic> flavorsObj = getListFromJArray(pokemonSpeciesJson["flavor_text_entries"]);
            string[] types = typesObj.Select(type => (string)type.type.name).Cast<string>().ToArray();
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
    }
}