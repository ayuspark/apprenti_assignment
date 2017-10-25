using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace asp_candyman.Controllers
{
    public class PokeAPIController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.haro = "haro";
            return View("PokeAPI");
        }


        [HttpGet]
        [Route("pokeapi")]
        public IActionResult Pokeapi(int pokeid)
        {
            Dictionary<string, dynamic> pokeResponse = new Dictionary<string, dynamic>();

            // passing JObject can work too
            // JObject pokeResponse = new JObject();

            WebRequest.GetPokeapiResponse(pokeid, api_response => 
            {
                pokeResponse = api_response;
            }).Wait();

            ViewData["name"] = pokeResponse["name"];
            ViewData["weight"] = pokeResponse["weight"];
            ViewData["height"] = pokeResponse["height"];
            ViewBag.Type = pokeResponse["types"];

            return View("PokeAPI");
        }
    }
}
