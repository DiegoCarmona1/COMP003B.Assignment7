using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }
    }
}
