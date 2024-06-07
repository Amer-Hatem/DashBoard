namespace DashBoard.ViewModel
{
    public class BookVM
    {
      public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string Auther { get; set; } = null!;


        public string publisher { get; set; } = null!;
      
        public DateTime publisherDate { get; set; }  

 
        public  string ImageUrl { get; set; }
        public List<string> Categorise { get; set; }

    }
}
