using coreWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreWebApplication.Controllers
{
    public class DemoController : Controller
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() { CustomerId = 1, CustomerName = "SHit", Amount=12000 },
            new Customer() { CustomerId = 2, CustomerName = "Wtf", Amount=12000 }
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Managment System";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.CustomerList = customers;
            return View();
        }

        public IActionResult Details()
        {
            ViewData["Message"] = "Content Managment System";
            ViewData["CustomerCount"] = customers.Count();
            ViewData["CustomerList"] = customers;
            return View();
        }

        public IActionResult Method1()
        {
            TempData["Message"] = "Content Managment System";
            TempData["CustomerCount"] = customers.Count();
            TempData["CustomerList"] = customers;
            return View();
        }

        public IActionResult Method2()
        
        {
            if (TempData["Message"] == null)
            
                return RedirectToAction("Index");

            TempData["Message"] = TempData["Message"].ToString();
            //ViewBag.CustomerCount = TempData["CustomerCount"];
            //ViewBag.CustomerList = TempData["CustomerList"];
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("username", "to my .net web app");
            return RedirectToAction("Success");
        }

        public IActionResult Success()
        {
            ViewBag.UserName = HttpContext.Session.GetString("username");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }


        //Request url
        public IActionResult QueryTest()
        {
            string name = "Fabio Saraseli";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
            name = HttpContext.Request.Query["name"];
            ViewBag.Name = name;
            return View();
        }
    }
}
