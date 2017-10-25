using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_candyman.Controllers
{
    public class TMDBController : Controller
    {
        private readonly TMDBOptions _TMDBConfig;

        public TMDBController(IOptions<TMDBOptions> config)
        {
            _TMDBConfig = config.Value;
        }
      
        internal string APIKey
        {
            get
            {
                return _TMDBConfig.APIKey;   
            }
        }



        [HttpGet]
        [Route("/movies")]
        public IActionResult Index()
        {
            Console.WriteLine("apikey: " + APIKey);
            ViewData["Title"] = "TMDB";
            return View("TMDB");
        }
    }
}

