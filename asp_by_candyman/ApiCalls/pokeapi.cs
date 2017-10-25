using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Options;

namespace asp_candyman
{
    public class WebRequest
    {
        public static async Task GetPokeapiResponse(int pokeid, Action<Dictionary<string, dynamic>> Callback)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokeid}/");
                    HttpResponseMessage response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    // JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(stringResponse);

                    JObject tokens = JObject.Parse(stringResponse);

                    string name = (string)tokens.SelectToken("forms[0].name");
                    int height = (int)tokens.SelectToken("height");
                    int weight = (int)tokens.SelectToken("weight");
                    List<string> types = new List<string>();
                    JArray typesFromApi = (JArray)tokens.SelectToken("types");
                    foreach (var obj in typesFromApi)
                    {
                       types.Add(obj["type"]["name"].ToString());
                       Console.WriteLine(obj["type"]["name"]);
                    }

                    Dictionary<string, dynamic> cleanedResponse = new Dictionary<string, dynamic>
                    {
                        {"name", name},
                        {"height", height},
                        {"weight", weight},
                        {"types", types},
                    };

                    Callback(cleanedResponse);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"Request exceptions: {e.Message}");
                }
            }
        }

      
        public static async Task GetTMDBapiReponse(string name, string apiKey, Action<Dictionary<string, dynamic>> Callback)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri($"https://api.themoviedb.org/3/search/movie?api_key={apiKey}&query={name}");
                    HttpResponseMessage response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();
                    string stringResponse = await response.Content.ReadAsStringAsync();

                    JObject tokens = JObject.Parse(stringResponse);

                    float rating = (float)tokens.SelectToken("results[0].vote_average");
                    DateTime release = Convert.ToDateTime(tokens.SelectToken("results[0].release_date"));
                    string title = (string)tokens.SelectToken("results[0].title");

                    Dictionary<string, dynamic> cleanedResponse = new Dictionary<string, dynamic>
                    {
                        {"title", title},
                        {"rating", rating},
                        {"release", release},
                    };
                    Callback(cleanedResponse);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"Request exceptions: {e.Message}");
                }
            }
        }

    }
}