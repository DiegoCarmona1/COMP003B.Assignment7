

namespace COMP003B.Assignment7.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual Book? Books { get; set; }
        public virtual Author? Authors { get; set; }
    }
}
