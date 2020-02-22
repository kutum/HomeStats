using HomeStats.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace HomeStats.Controllers
{
    public class HomeController : Controller
    {
        HouseRepository repository = HouseRepository.Current;

        public ViewResult Index()
        {
            return View(repository.GetAll());
        }

        public HomeController(Context context)
        {
            repository.db = context;
        }
        
        public IActionResult Add(House house)
        {
            if (ModelState.IsValid)
            {
                repository.Add(house);
                return RedirectToAction("Index");
            }
            else return View("Index");
        }

        public IActionResult Update (House house)
        {
            if(ModelState.IsValid && repository.Update(house))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public IActionResult Remove(int Id)
        {
            repository.Remove(Id);
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
