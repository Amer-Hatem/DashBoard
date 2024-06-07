using System.ComponentModel.DataAnnotations;

namespace DashBoard.ViewModel
{
    public class AutherFormVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = ("insert name"))]
        [MaxLength(30)]
        public string Name { get; set; } = null!;
    }
}
