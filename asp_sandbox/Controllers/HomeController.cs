using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using asp_sandbox.Models;

namespace asp_sandbox.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("default")]
        public IActionResult IndexDefault()
        {
            return View("Index");
        }


        [HttpGet]
        [Route("haro")]
        public string Index()
        {
            return "Haro World";
        }


        [HttpGet]
        [Route("json/")]
        public JsonResult JsonStuff()
        {
            Dictionary<string, string> dickt = new Dictionary<string, string> {
                {"haro", "world?!?"},
            };

            var anonymousObj = new {
                name = "lola",
                age = 11,
                dickt,
            };

            return Json(anonymousObj);
        }


        [HttpGet]
        [Route("callingCards/{fname}/{lname}/{age}/{color}")]
        public JsonResult CallingCards(string fname, string lname, int age, string color)
        {
            var fromUrl = new
            {
                first_name = fname,
                last_name = lname,
                age = age,
                color = color,
            };
            return Json(fromUrl);
        }


        [HttpGet]
        [Route("showtime")]
        public IActionResult showTime()
        {
            return View("showtime");
        }


        [HttpGet]
        [HttpPost]
        [Route("showtime/survey")]
        public IActionResult SurveyForm(string name, string location, string lang, string comment)
        {
            if (name == null || location == null || lang == null || comment == null )
            {
                ViewBag.Error = "All fields are required apparently duh.";
                return View("showtime");
            } else {
                ViewBag.name = name;
                ViewBag.location = location;
                ViewBag.lang = lang;
                ViewBag.comment = comment;
            }
            return View("showtime");
        }


        [HttpGet]
        [Route("randompass")]
        public IActionResult RandomPass()
        {
            try
            {
                int? count = HttpContext.Session.GetInt32("count");
                count += 1;
                HttpContext.Session.SetInt32("count", (int)count);
                ViewBag.count = count;
            }
            catch(InvalidOperationException){
                HttpContext.Session.SetInt32("count", 0);
                ViewBag.count = 0;
            }

            string chars = "ABCDESFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random rand = new Random();
            string passcode = "";
            for (int i = 0; i < 15; i++)
            {
                passcode += chars[rand.Next(0, chars.Length)];
            }
            passcode.ToUpper();
            ViewBag.passcode = passcode;
            return View("randompass");
        }
       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
