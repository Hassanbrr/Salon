using DataAccess.Base;
using DataAccess.Context;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace Salon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var servicesList = _unitOfWork.Service.FindAll(includeProperties: "Category").ToList();
            return View(servicesList);
        }


        public IActionResult Upsert(int? id)
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
            if (id == 0 || id == null)
            {
                //create
                return View(serviceList);
            }
            else
            {
                //update
                serviceList.Services = _unitOfWork.Service.FindByCondition(u => u.ServiceId == id).FirstOrDefault();
                return View(serviceList);
            }

        }
        [HttpPost]
        public IActionResult Upsert(ServiceVm obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {

                if (file != null)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    //finaly name
                    string fileName = Guid.NewGuid().ToString() + Path.GetFileNameWithoutExtension(file.FileName) + ".jpg";
                    //finaly masir
                    string productPath = Path.Combine(wwwRootPath, @"Images\Service");

                    if (!string.IsNullOrEmpty(obj.Services.ImageUrl))
                    {
                        //delete old image
                        var OldImagePath = Path.Combine(wwwRootPath, obj.Services.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(OldImagePath))
                        {
                            System.IO.File.Delete(OldImagePath);
                        }

                    }

                    //uplode new image
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                  

                    obj.Services.ImageUrl = @"\Images\Service\" + fileName;
                }
                if (obj.Services.ServiceId == 0)
                {
                    _unitOfWork.Service.Create(obj.Services);
                }
                else
                {
                    _unitOfWork.Service.Update(obj.Services);
                }

                _unitOfWork.SaveChangesAsync();
                TempData["success"] = "Service Created Successfully";

                return RedirectToAction("Index");
            }
            else
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
}
