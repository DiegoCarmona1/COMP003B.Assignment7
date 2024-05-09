using COMP003B.Assignment7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace COMP003B.Assignment7.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)
        { 
        }

        public DbSet<BookModel> bookModels { get; set; }
        public DbSet<AuthorModel> authorModels { get; set; }
        public DbSet<BookAuthorModel> bookAuthorModels { get; set; }
    }
}
