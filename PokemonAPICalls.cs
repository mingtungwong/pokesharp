using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace pokesharp {

    class PokemonAPIClient {
        private static HttpClient client = new HttpClient();

        public PokemonAPIClient() {
            client.BaseAddress = new Uri("http://pokeapi.co/api/v2/");
        }

        public Pokemon getPokemon(string idOrName) {
            // Make two API calls to get all the relevant Pokemon data.
            HttpResponseMessage pokemonResponse = client.GetAsync($"pokemon/{idOrName}").Result;
            HttpResponseMessage pokemonSpeciesResponse = client.GetAsync($"pokemon-species/{idOrName}").Result;

            // Check if both calls return a HTTP OK response.
            if(pokemonResponse.IsSuccessStatusCode && pokemonSpeciesResponse.IsSuccessStatusCode) {
                // Change the information into a string.
                string pokemonString = pokemonResponse.Content.ReadAsStringAsync().Result;
                string speciesString = pokemonSpeciesResponse.Content.ReadAsStringAsync().Result;
                // Use Newtonsoft library to deserialize.
                dynamic pokemonJson = JsonConvert.DeserializeObject<object>(pokemonString);
                dynamic speciesJson = JsonConvert.DeserializeObject<object>(speciesString);
                // Use helper class/method to parse the information and create a Pokemon object.
                Pokemon p = PokemonUtils.createPokemonObject(pokemonJson, speciesJson);
                // Return the created Pokemon.
                return p;
            } else return null;
        }
    }

}