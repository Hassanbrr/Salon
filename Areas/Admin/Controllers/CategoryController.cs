using DataAccess.Base;
using DataAccess.Context;
using Domain.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Salon.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var categoriesList = await _unitOfWork.Category.FindAll(includeProperties:"ParentCategory").ToListAsync();

            return View(categoriesList);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
           
         
           
                var categories = _unitOfWork.Category.FindAll().ToList();
                var viewModel = new CategoryViewModel
                {
                    ParentCategories = categories.Select(c => new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName
                    })
                }; 
             
                return View(viewModel);
   
           

        }
        [HttpPost]
       
        public IActionResult Create(CategoryViewModel obh)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    ParentCategoryId = obh.ParentCategoryId,
                    CategoryName = obh.CategoryName,
                    Description = obh.Description,
                    CreatedAt = DateTime.Now,
                    Slug = obh.Slug
                };

                _unitOfWork.Category.Create(category);
                _unitOfWork.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // در صورت خطا، مجدداً لیست دسته‌بندی‌های والد را ارسال کن
            var categories = _unitOfWork.Category.FindAll().ToList();

            obh.ParentCategories = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            });

            return View(obh);
        }




    }
}
