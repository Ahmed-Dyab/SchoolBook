using Microsoft.AspNetCore.Mvc;
using schoolbook.Models;

namespace schoolbook.Controllers
{
    public class UserProfileController : Controller
    {
        SchoolBookEntities context=new SchoolBookEntities();

       // [HttpPost]
        public IActionResult Profile(string email,string password)
         {
            var user = context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return RedirectToAction("SignIn", "SignIn");
            }
            else if (user.Password == password)
            {
                ViewBag.userbook = context.Books.Where(x => x.UserId == user.Id).Take(5).ToList();
                ViewBag.userbooksize = context.Books.Where(x => x.UserId == user.Id).Count();
                return View("Profile", user);
            }
            return RedirectToAction("SignIn", "SignIn");
        }
        public IActionResult EditeProfile()
        {
            return View("EditeProfile");
        }
    }
}
