using Microsoft.AspNetCore.Mvc;
using StudentTaskManagementSystem.Data;
using StudentTaskManagementSystem.Models;

namespace StudentTaskManagementSystem.Controllers
{
    public class UserCredentialController : Controller
    {
        protected ApplicationDbContext _db;
        public UserCredentialController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        public IActionResult ReceiveRegisterUser(UserModel user)
        {
            var usr = _db.UserCredentials.FirstOrDefault(u => u.UserName == user.UserName || u.Email == user.Email);
            if(usr != null)
            {
                return Content("Username or email alredy exits!");
            }
            _db.UserCredentials.Add(user);
            _db.SaveChanges();
            return RedirectToAction("LoginUser");
        }
        public IActionResult LoginUser()
        {
            return View();
        }
        public IActionResult ReceiveLoginUser(UserModel user)
        {
            var users = _db.UserCredentials.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if(users != null)
            {
                HttpContext.Session.SetInt32("CurrentUser",users.UserId);
                return RedirectToAction("DisplayTask", "StudentTask");
            }
            else
            {
                return RedirectToAction("LoginUser");
            }
        }
        public IActionResult LogoutUser()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginUser");
        }
    }
}
