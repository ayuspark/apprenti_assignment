using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace asp_identity_core_ef.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            Console.WriteLine("************" + User.Identity.IsAuthenticated);
            return View("Index");
        }
    }
}
