using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class AuthorModel
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookAuthorModel>? BookAuthorModels { get; set; }

        public int Age { get; set; }
    }
}
