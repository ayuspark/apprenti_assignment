using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace asp_candyman.Controllers
{
    public class QuotesController : Controller
    {
        private readonly DbConnector _dbConnector;

        public QuotesController(DbConnector connect)
        {
            _dbConnector = connect;
        }


        [HttpGet]
        [Route("quote")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Quotes";
            ViewBag.Error = TempData["error"];

            string query = $"SELECT users.id as user_id, quotes.id as quote_id, name, quote, created FROM quotesDB.users JOIN quotesDB.quotes WHERE users.id = quotes.users_id ORDER BY created DESC";
            List<Dictionary<string, object>> allQuotes = new List<Dictionary<string, object>>();
            allQuotes = _dbConnector.Query(query);
            ViewBag.allQuotes = allQuotes;

            return View("Quotes");
        }


        [HttpPost]
        [Route("quote/add")]
        public IActionResult AddQuote(string name, string quote)
        {
            string query;

            if (name == null || quote == null)
            {
                TempData["error"] = "all fields required!";
                return RedirectToAction("Index");
            }
        
            string user_id_query = $"SELECT id FROM quotesDB.users WHERE name = '{name}'";
            List<Dictionary<string, object>> test = _dbConnector.Query($"SELECT id FROM quotesDB.users WHERE name = '{name}'");
            if (test.Count == 0 )
            {
                query = $"INSERT INTO quotesDB.users(name) VALUES('{name}')";
            } else
            {
                string id = test.First()["id"].ToString();
                query = $"INSERT INTO quotesDB.quotes(quote, created, users_id) VALUES('{quote}', NOW(), '{id}')";
            }
            _dbConnector.Execute(query);
            return RedirectToAction("QuotesAll");
        }
    }
}