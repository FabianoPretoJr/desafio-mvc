using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projeto.Models;
using projeto.Data;

namespace projeto.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext database;
        public HomeController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var login = database.popular.Where(p => p.ClaimCont == "Login" && p.ValueCont == true).ToList();

            if(login.Any())
            {
                ViewData["cont1"] = false;
            }
            else
            {
                ViewData["cont1"] = true;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
