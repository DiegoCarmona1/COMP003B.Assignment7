using System.ComponentModel.DataAnnotations;

namespace COMP003B.Assignment7.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BookAuthor>? BookAuthors { get; set; }

        public int Age { get; set; }
    }
}
