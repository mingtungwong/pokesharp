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
            HttpResponseMessage pokemonResponse = client.GetAsync($"pokemon/{idOrName}").Result;
            HttpResponseMessage pokemonSpeciesResponse = client.GetAsync($"pokemon-species/{idOrName}").Result;
            if(pokemonResponse.IsSuccessStatusCode && pokemonSpeciesResponse.IsSuccessStatusCode) {
                string pokemonString = pokemonResponse.Content.ReadAsStringAsync().Result;
                string speciesString = pokemonSpeciesResponse.Content.ReadAsStringAsync().Result;
                dynamic pokemonJson = JsonConvert.DeserializeObject<object>(pokemonString);
                dynamic speciesJson = JsonConvert.DeserializeObject<object>(speciesString);
                Pokemon p = PokemonUtils.createPokemonObject(pokemonJson, speciesJson);
                return p;
            } else return null;
        }
    }

}