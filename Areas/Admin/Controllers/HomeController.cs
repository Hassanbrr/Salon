using DataAccess.Base;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Salon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Create()
        //{
        //    ServiceVm serviceList = new()
        //    {

        //        CategoryList = _unitOfWork.Category.FindAll().Select(u => new SelectListItem
        //        {
        //            Text = u.CategoryName,
        //            Value = u.CategoryId.ToString()
        //        }),
        //        Services = new Service()
        //    };

        //    return View(serviceList);
        //}
    }
}
