﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [Route("showtime/survey")]
        public IActionResult SurveyForm(string name, string location, string lang, string comment)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.lang = lang;
            ViewBag.comment = comment;
            return View("showtime");
        }


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
