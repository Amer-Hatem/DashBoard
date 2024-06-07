using DashBoard.Data;
using DashBoard.Models;
using DashBoard.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Controllers
{
    public class BookController : Controller
    {
        public ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext context , IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var books = context.Books.Include(book => book.Auther).Include(book => book.Categories)
                .ThenInclude(book => book.Category).ToList();

            var bookVms = books.Select(item=> new BookVM
            {
                Id = item.Id,
                Title = item.Title,
                Auther = item.Auther.Name,
                publisher = item.publisher,
                publisherDate = item.publisherDate,
                ImageUrl = item.ImageUrl,
                Categorise = item.Categories.Select(item=>item.Category.Name).ToList(),

            }).ToList();


           


            return View(bookVms);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var authers = context.Authers.OrderBy(auther => auther.Name).ToList();
            var categories = context.Categories.OrderBy(category => category.Name).ToList();

            var autherlist = authers.Select(auther => new SelectListItem
            {
                Value = auther.Id.ToString(),
                Text = auther.Name
            }).ToList();

            var categorylist = categories.Select(category => new SelectListItem
            {
                Value = category.Id.ToString(),
                Text = category.Name
            }).ToList();

            var vm = new BookFormVM
            {
                Authers = autherlist,
                Categorise = categorylist
            };

            return View(vm);
        }


        [HttpPost]
        public IActionResult Create(BookFormVM bookFormVM)
        {
            if(!ModelState.IsValid)
            {
                return View(bookFormVM);
            }
            string imgName = null;
            if (bookFormVM.ImageUrl != null)
            {
                 imgName = Path.GetFileName(bookFormVM.ImageUrl.FileName);
                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/img/book", imgName);
                var stream = System.IO.File.Create(path);
                bookFormVM.ImageUrl.CopyTo(stream);
            }
            var book = new Book
            {
                Title = bookFormVM.Title,
                AutherId = bookFormVM.AutherId,
                publisher = bookFormVM.publisher,
                publisherDate = bookFormVM.publisherDate,
                Description = bookFormVM.Description,
                ImageUrl= imgName,
                Categories = bookFormVM.SelectCate.Select(id => new BookCategory
                {
                    CategoryId = id,
                }).ToList(),
            };
            context.Books.Add(book); 
            context.SaveChanges();

            return RedirectToAction("Index");








        }

    }
}
