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
            }
            if (myPet.Fullness == 100 || myPet.Happiness == 100)
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
        [Route("/pet/feed")]
        public IActionResult Feed()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            myPet = myPet.Feed();
            TempData["caption"] = myPet.output;
            HttpContext.Session.SetObjectAsJson("myPet", myPet);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("/pet/play")]
        public IActionResult Play()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            myPet = myPet.Play();
            TempData["caption"] = myPet.output;
            HttpContext.Session.SetObjectAsJson("myPet", myPet);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("/pet/sleep")]
        public IActionResult Sleep()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            myPet = myPet.Sleep();
            TempData["caption"] = myPet.output;
            HttpContext.Session.SetObjectAsJson("myPet", myPet);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("/pet/work")]
        public IActionResult Work()
        {
            myPet = HttpContext.Session.GetObjectFromJson<Pet>("myPet");
            myPet = myPet.Work();
            TempData["caption"] = myPet.output;
            HttpContext.Session.SetObjectAsJson("myPet", myPet);
            return RedirectToAction("Index");
        }


        [HttpPost]
        [Route("/pet/reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        } 
    }
}
