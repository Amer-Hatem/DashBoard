using System.ComponentModel.DataAnnotations;

namespace DashBoard.Models
{
    public class CategoryVM
    {
        public int ID { get; set; } 
        [Required(ErrorMessage =("insert name"))]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpDate { get; set; } = DateTime.Now;


    }
}
