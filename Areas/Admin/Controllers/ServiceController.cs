using DataAccess.Base;
using DataAccess.Context;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Salon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var servicesList = _unitOfWork.Service.FindAll(includeProperties: "Category").ToList();
            return View(servicesList);
        }

   
        public IActionResult Create()
        {
            ServiceVm serviceList = new()
            {

                CategoryList = _unitOfWork.Category.FindAll().Select(u => new SelectListItem
                {
                    Text = u.CategoryName,
                    Value = u.CategoryId.ToString()
                }),
                Services = new Service()
            };

            return View(serviceList);
        }
    }
}
