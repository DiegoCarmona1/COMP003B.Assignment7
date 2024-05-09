using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<BookAuthorModel>? BookAuthorModels { get; set; }
    }
}
