using COMP003B.Assignment7.Models;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Assignment7.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext (DbContextOptions<WebDevAcademyContext> options)
            : base(options)

        { 
        }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<BookAuthorModel> BookAuthor { get; set; }
    }
}
