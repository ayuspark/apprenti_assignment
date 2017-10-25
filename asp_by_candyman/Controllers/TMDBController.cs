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
        //******** use option injection to hide apiKeys, and DBconnection ********
        private readonly TMDBOptions _TMDBConfig;
        private readonly DbConnector _dbConnector;

        public TMDBController(IOptions<TMDBOptions> config, DbConnector connect)
        {
            _TMDBConfig = config.Value;
            _dbConnector = connect;
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
            ViewData["Title"] = "TMDB";
            string query = $"SELECT name as title, rating, `release` FROM movies";
            List<Dictionary<string, object>> all_movies = _dbConnector.Query(query);

            ViewBag.all_movies = all_movies;

            return View("TMDB");
        }


        [HttpPost]
        [Route("/movies/search")]
        public IActionResult Search(string name)
        {
            Dictionary<string, dynamic> movieResponse = new Dictionary<string, dynamic>();
            WebRequest.GetTMDBapiReponse(name, APIKey, apiResponse => {
                movieResponse = apiResponse;   
            }).Wait();

            string title = movieResponse["title"];
            float rating = movieResponse["rating"];
            string release = movieResponse["release"];

            string query = $"INSERT INTO movies(name, rating, `release`) VALUES('{title}', {rating}, '{release}')";
            _dbConnector.Execute(query);

            ViewBag.movieTitle = title;
            ViewBag.rating = rating;
            ViewBag.release = release;

            return PartialView("QueryTemplate");
        }

    }
}

