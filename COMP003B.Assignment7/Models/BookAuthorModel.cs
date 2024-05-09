using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment7.Models
{
    public class BookAuthorModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public virtual BookModel? Book { get; set; }
        public virtual AuthorModel? Author { get; set; }
    }
}
