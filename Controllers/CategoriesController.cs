using DashBoard.Data;
using DashBoard.Data.Migrations;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DashBoard.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context)
        { 
        this.context = context;
                }


        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryVM CategoryVM)
        {
            if(!ModelState.IsValid)
            {
                return View("Create", CategoryVM);
            }
            var category = new Category()
            {
                Name = CategoryVM.Name,
            };
            context.Categories.Add(category); 
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit( )
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Edit(CategoryVM CategoryVM)
        {
            var category = context.Categories.Find(CategoryVM.ID);
            if(category == null)
            {
                NotFound();
            }
            category.Name = CategoryVM.Name;
       
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);
            category.UpDate= DateTime.Now;
            if (category == null)
            {
                NotFound();
            }

            var vm = new CategoryVM()
            {
                ID = category.Id,
                Name = category.Name,
                CreatedDate = category.CreatedDate,

                UpDate = category.UpDate
            };
            return View(vm);
        }
        public IActionResult Delete(int id)
        {
            var Category = context.Categories.Find(id);
            context.Categories.Remove(Category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
