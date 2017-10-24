using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace asp_candyman
{
    public class WebRequest
    {
        public static async Task GetPokeapiResponse(int pokeid, Action<Dictionary<string, object>> Callback)
        {
            using(var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri($"https://pokeapi.co/api/v2/pokemon/{pokeid}/");
                    HttpResponseMessage response = await client.GetAsync("");
                    response.EnsureSuccessStatusCode();
                    string stringResponse = await response.Content.ReadAsStringAsync();
                    Dictionary<string, object> jsonResponse = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
                    Callback(jsonResponse);
                    Console.WriteLine("json resp " + jsonResponse);
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine($"Request exceptions: {e.Message}");
                }
            }
        }

    }
}