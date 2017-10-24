using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace asp_candyman.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.haro = "haro";
            return View("Index");
        }


        [HttpGet]
        [Route("pokeapi")]
        public IActionResult Pokeapi(int pokeid)
        {
            var pokeResponse = new Dictionary<string, dynamic>();
            WebRequest.GetPokeapiResponse(pokeid, api_response => 
            {
                pokeResponse = api_response;
            }).Wait();

            Console.WriteLine(pokeResponse);
            ViewData["name"] = pokeResponse["forms"][0]["name"];
            ViewData["weight"] = pokeResponse["weight"];
            ViewData["height"] = pokeResponse["height"];
            //List<object> pokeTypeList = pokeResponse["types"];

            List<string> typeResult = new List<string>();
            foreach (var el in pokeResponse["types"])
            {
                string toAdd = el["type"]["name"];
                typeResult.Add(toAdd);
            }
            ViewBag.Type = typeResult;

            return View("Index");
        }
    }
}
