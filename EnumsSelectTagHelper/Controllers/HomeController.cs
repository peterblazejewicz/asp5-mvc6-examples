using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using EnumsSelectTagHelper.ViewModels;

namespace EnumsSelectTagHelper.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new PersonalDetailsViewModel();
            return View(model);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
