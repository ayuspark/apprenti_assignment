using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using asp_candyman.Models;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace asp_candyman.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnector _dbConnector;

        public UserController(DbConnector connect)
        {
            _dbConnector = connect;
        }


        [HttpGet]
        [Route("user")]
        public IActionResult Index()
        {
            
            ViewData["success"] = TempData["success"];
            return View("Index");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserRegister user)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM logreg WHERE email = '{user.Email}'";
                List<Dictionary<string, dynamic>> result = _dbConnector.Query(query);
                Console.WriteLine(result.Any());
                if (result.Any())
                {
                    ViewData["success"] = "User exists. Please log in.";
                    return View("Index");
                }
                else
                {
                    RegisterUserToDB(user);
                    TempData["success"] = "Registered!";
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }


        [HttpPost]
        [Route("login")]
        public IActionResult Login(UserLogin user)
        {
            if (ModelState.IsValid)
            {
                string query = $"SELECT * FROM logreg WHERE email = '{user.LoginEmail}'";
                List<Dictionary<string, dynamic>> result = _dbConnector.Query(query);

                if (result.Any())                
                {
                    PasswordHasher<UserLogin> hasher = new PasswordHasher<UserLogin>();
                    if (hasher.VerifyHashedPassword(user, (string)result.First()["password"], user.LoginPassword) == 0)
                    {
                        ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
                    }
                    else
                    {
                        TempData["success"] = "Logged in!";
                        HttpContext.Session.SetInt32("user_id", (int)result.First()["id"]);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["success"] = "User does not exist, go to login.";
                    return RedirectToAction("Index");
                }
            }
            return View("Index");
        }


        public void RegisterUserToDB(UserRegister user)
        {
            PasswordHasher<UserRegister> hasher = new PasswordHasher<UserRegister>();
            string hashed = hasher.HashPassword(user, user.Password);
            string query = $"INSERT INTO logreg(fname, lname, password, email)" +
                $"VALUES ('{user.FName}', '{user.LName}', '{hashed}', '{user.Email}'); " +
                "SELECT LAST_INSERT_ID() as id";
            int user_id = Convert.ToInt32(_dbConnector.Query(query).First()["id"]);
            HttpContext.Session.SetInt32("user_id", user_id);
        }
    }
}
