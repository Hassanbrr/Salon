using Microsoft.AspNetCore.Mvc;

namespace Salon.Areas.Clint.Controllers
{
    [Area("Clint")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
