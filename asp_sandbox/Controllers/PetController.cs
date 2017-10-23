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
        //public PetController()
        //{
        //    try
        //    {
        //        myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
        //    }
        //    catch(NullReferenceException)
        //    {
        //        myPet = new Pet();
        //        HttpContext.Session.SetObjectAsJson("myPet", myPet);
        //    }
        //}

        [HttpGet]
        [Route("pet")]
        public IActionResult Index()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            if (myPet == null)
            {
                myPet = new Pet();
                HttpContext.Session.SetObjectAsJson("myPet", myPet);
                Console.WriteLine("I am new");
                Console.WriteLine(myPet.Meal);
                Console.WriteLine(myPet.Fullness);
            }
            ViewBag.fullness = myPet.Fullness;
            ViewBag.happiness = myPet.Happiness;
            ViewBag.energy = myPet.Energy;
            ViewBag.meal = myPet.Meal;
            ViewBag.caption = TempData["caption"];

            Console.WriteLine("Index outside if: " + myPet.Meal);
            Console.WriteLine("Index outside if"+ myPet.Fullness);
           
            return View("PetIndex");
        }


        [HttpPost]
        [Route("/pet/feed")]
        public IActionResult Feed()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            myPet = myPet.Feed();
            TempData["caption"] = myPet.output;
            Console.WriteLine("from feed: " + myPet.Meal);
            Console.WriteLine("from feed: " + myPet.Fullness);
            HttpContext.Session.SetObjectAsJson("myPet", myPet);
            return RedirectToAction("Index");
        }
    }
}
