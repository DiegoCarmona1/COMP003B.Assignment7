using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Assignment7.Models
{
    public class AuthorModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
