using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;

namespace WebApplication1.ViewModels
{
    public class ReviewVM
    {
        public int? Id { get; set; }
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        [DisplayName("User")]
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public string? UserName { get; set; }
        [DisplayName("Book")]

        public string? BookTitle { get; set; }
    }
}
