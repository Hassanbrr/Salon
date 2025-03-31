using Microsoft.AspNetCore.Mvc;

namespace Salon.Areas.Admin.Controllers
{
    public class GalleryWebSiteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
