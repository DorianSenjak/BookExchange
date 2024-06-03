namespace WebApplication1.ViewModels
{
    public class BookVM
    {

        public int Idbook { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Isbn { get; set; }

        public DateTime? PublicationDate { get; set; }

        public string? CoverPageImage { get; set; }

        public string? Publisher { get; set; }

        public int? Pages { get; set; }
    }
}
