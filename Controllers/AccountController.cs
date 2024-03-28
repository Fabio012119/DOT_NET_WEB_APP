using coreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreWebApplication.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeeklyTypedLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }

        public IActionResult StronglyTypedLogin(string username, string password)
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if (login.Username != null && login.Password != null)
            {
                if (login.Username.Equals("admin") && login.Password.Equals("admin"))
                {
                    ViewBag.Message = "You are successgully logged in.";
                    return View();
                }
            }
            ViewBag.Message = "Invalid credentials";
            return View();
        }

        public IActionResult UserDetails()
        {
            var user = new LoginViewModel() { Username = "Bhawna", Password = "123456" };
            return View(user);
        }

        public IActionResult UserList()
        {

            var users = new List<LoginViewModel>()
            {
                new LoginViewModel() {Username = "Bhana", Password = "123456"},
                new LoginViewModel() {Username = "Hitesh", Password = "123456"},
                new LoginViewModel() {Username = "kash", Password = "123456"},
            };

            return View(users);
        }

        public IActionResult GetAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if(ModelState.IsValid)
            {
                return View("Success");
            }
            return RedirectToAction("GetAccount");
        }
    }
}
