using DataAccess.Base;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;

namespace Salon.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServiceController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var servicesList = _unitOfWork.Service.FindAll(includeProperties: "").ToList();
            return View(servicesList);
        }
    }
}
