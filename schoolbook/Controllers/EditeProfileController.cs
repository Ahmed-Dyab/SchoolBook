using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using schoolbook.Models;
using schoolbook.viewmodel;

namespace schoolbook.Controllers
{
    public class EditeProfileController : Controller
    {
        SchoolBookEntities context=new SchoolBookEntities();
        private readonly IWebHostEnvironment host;
        public EditeProfileController(IWebHostEnvironment host)
        {
            this.host = host;
        }
        public IActionResult EditeProfile(int id)
        {
            var user=context.Users.FirstOrDefault(x => x.Id == id);
            
            return View("EditeProfile", user);
        }
        public string filename =string.Empty;
        public IActionResult SaveChange(int id,User user,userviewmodel usermodel)
        {
            User? use = context.Users.FirstOrDefault(u => u.Id == id);
             
            if (use.Email == user.Email|| context.Users.FirstOrDefault(u => u.Email == user.Email)==null)
            {
                if (use != null && user.FirstName != "" && user.LastName != "" && user.PhoneNumber != ""
                    && user.Email != "" && user.Governorate != "" && user.Central != "")
                {
                    if (usermodel.file != null)
                    {
                        string path = Path.Combine(host.WebRootPath, "userimages");
                        filename = usermodel.file.FileName;
                        string fullpath = Path.Combine(path, filename);
                        string oldimge = use.Image;
                        string fulloldimage = Path.Combine(path, oldimge);
                        if(oldimge!="defult.jpg")
                        System.IO.File.Delete(fulloldimage);
                        usermodel.file.CopyTo(new FileStream(fullpath, FileMode.Create));
                        use.Image = filename;
                    }
                    use.FirstName = user.FirstName; use.LastName=user.LastName;use.PhoneNumber=user.PhoneNumber;
                    use.Governorate=user.Governorate; use.Central=user.Central;use.Email=user.Email;
                    
                    context.SaveChanges();
                    return RedirectToAction ("Profile", "UserProfile", new {email=use.Email ,password=use.Password });
                }
                else
                    return RedirectToAction("EditeProfile",id);
            }
            else
            {
                return RedirectToAction("EditeProfile", id);
            }
            
        }
    }
}
