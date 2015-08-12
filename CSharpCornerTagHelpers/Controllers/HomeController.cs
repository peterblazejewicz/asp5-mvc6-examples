using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CSharpCornerTagHelpers.Models;

namespace CSharpCornerTagHelpers.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string successMessage)
        {
            ViewBag.Success = successMessage;
            return View();
        }

        public IActionResult CreateUser(User model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { successMessage = "Success" });
            }
            return View("Index", model);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
