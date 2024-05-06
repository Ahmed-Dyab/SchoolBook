using Microsoft.AspNetCore.Mvc;
using schoolbook.Models;

namespace schoolbook.Controllers
{
    public class SignInController : Controller
    {
        SchoolBookEntities context=new SchoolBookEntities();
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckSignin(string email,string password)
        {
            var user=context.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return RedirectToAction("SignIn");
            }
            else if(user.Password == password)
            {
                return RedirectToAction("Profile",user);
            }

            return RedirectToAction("SignIn");
        }
    }
}
