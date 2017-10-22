using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sandbox_dotnet_asp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGetAttribute]
        public string Index()
        {
            return "Haro World.";
        }
    }
    
}