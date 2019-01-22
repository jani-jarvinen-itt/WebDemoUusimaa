using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreBackend.Models;

namespace AspNetCoreBackend.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult OmaJuttu()
        {
            return View();
        }

        public IActionResult Asiakkaat(string id)
        {
            NorthwindContext context = new NorthwindContext();
            
            if (id == null)
            {
                return View(context.Customers);
            }
            else
            {
                string maa = id;
                List<Customers> asiakkaat = (from c in context.Customers
                                             where c.Country == maa
                                             orderby c.CompanyName
                                             select c).ToList();

                return View(asiakkaat);
            }
        }
    }
}
