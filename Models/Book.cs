namespace DashBoard.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string publisher { get; set; } = null!;
        public DateTime publisherDate { get; set; }
        public int AutherId { get; set; }
        public Auther Auther { get; set; }
        public string? ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpDate { get; set; } = DateTime.Now;

        public List<BookCategory> Categories { get; set;} = new List<BookCategory>();

    }
}


