using Microsoft.AspNetCore.Mvc;

namespace schoolbook.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
