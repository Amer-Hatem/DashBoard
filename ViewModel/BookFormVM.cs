using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace DashBoard.ViewModel
{
    public class BookFormVM
    {
        public string Title { get; set; } 
public int Id { get; set; }
        [Display(Name ="Auther")]
        public int AutherId { get; set; }
        public List<SelectListItem>? Authers { get; set; }

        public string publisher { get; set; } = null!;
        [Display(Name = "publisher Date")]
        public DateTime publisherDate { get; set; } = DateTime.Now;

        [Display(Name = "choose a image  -_-    ")]
        public IFormFile? ImageUrl { get; set; }
        public string Description { get; set; } = null!;
        public List<int> SelectCate { get; set; } = new List<int>();
        public List<SelectListItem>? Categorise { get; set; }



    }
}
