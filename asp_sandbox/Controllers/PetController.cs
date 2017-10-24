using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_sandbox.Controllers
{
    public class PetController : Controller
    {
        private static Pet myPet { get; set; }


        [HttpGet]
        [Route("pet")]
        public IActionResult Index()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            if (myPet == null)
            {
                myPet = new Pet();
                HttpContext.Session.SetObjectAsJson("myPet", myPet);
            }
            if (myPet.Fullness >= 100 || myPet.Happiness >= 100)
            {
                ViewBag.caption = "You won! Some value reached 100, you can kill it now.";
                ViewBag.renderForm = false;
            } else if (myPet.Fullness == 0)
            {
                ViewBag.caption = "You starved it to death.";
                ViewBag.renderForm = false;
            } else
            {
                ViewBag.fullness = myPet.Fullness;
                ViewBag.happiness = myPet.Happiness;
                ViewBag.energy = myPet.Energy;
                ViewBag.meal = myPet.Meal;
                ViewBag.caption = TempData["caption"];
                ViewBag.renderForm = true;
            }
            return View("PetIndex");
        }


        [HttpPost]
        [Route("pet/{interaction}")]
        public IActionResult Action(string interaction)
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            if (interaction != "reset")
            {
                switch (interaction)
                {
                    case "feed":
                        myPet = myPet.Feed();
                        break;
                    case "play":
                        myPet = myPet.Play();
                        break;
                    case "sleep":
                        myPet = myPet.Sleep();
                        break;
                    case "work":
                        myPet = myPet.Work();
                        break;        
                }
                TempData["caption"] = myPet.output;
                HttpContext.Session.SetObjectAsJson("myPet", myPet);
            } else
            {
                HttpContext.Session.Clear();
                TempData["caption"] = "new pet!";
            }
            return RedirectToAction("Index");
        }
    }
}
