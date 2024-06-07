using DashBoard.Data;
using DashBoard.Models;
using DashBoard.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DashBoard.Controllers
{
    public class AuthersController : Controller
    {
        public ApplicationDbContext context;

        public AuthersController(ApplicationDbContext context )
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var authersVm = context.Authers
                .Select(item => new AutherVM
                {
                    ID = item.Id,
                    Name = item.Name,
                    CreatedDate = item.CreatedDate,
                    UpDate = item.UpDate
                })
                .ToList();

            return View(authersVm);
        }
        [HttpGet]
        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(AutherVM AutherVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", AutherVM);
            }
            var auther = new Auther()
            {
                Name = AutherVM.Name,
            };
            context.Authers.Add(auther);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View("Create");
        }
        [HttpPost]
        public IActionResult Edit(AutherVM AutherVM)
        {
            var auther = context.Authers.Find(AutherVM.ID);
            if (auther == null)
            {

            }
            auther.Name = AutherVM.Name;

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var auther = context.Authers.Find(id);
            auther.UpDate = DateTime.Now;
            if (auther == null)
            {
                NotFound();
            }

            var vm = new AutherVM()
            {
                ID = auther.Id,
                Name = auther.Name,
                CreatedDate = auther.CreatedDate,

                UpDate = auther.UpDate
            };
            return View(vm);
        }
        
 public IActionResult Delete(int id)
        {
            var auther = context.Authers.Find(id);
            context.Authers.Remove(auther);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
