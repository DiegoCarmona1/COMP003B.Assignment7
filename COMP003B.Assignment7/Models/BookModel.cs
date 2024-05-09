using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment7.Models
{
    public class BookModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
