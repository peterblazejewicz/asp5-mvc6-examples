using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace WebSearchWithElasticsearch.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
