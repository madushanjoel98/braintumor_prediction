using Microsoft.AspNetCore.Mvc;

namespace AuthApp.controller
{
    [Route("")] 
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
            return PhysicalFile(filePath, "text/html");
        }
    }
}
