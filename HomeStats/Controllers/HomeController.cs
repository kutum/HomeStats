using HomeStats.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace HomeStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly Context db;

        public HomeController(Context context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Houses.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
