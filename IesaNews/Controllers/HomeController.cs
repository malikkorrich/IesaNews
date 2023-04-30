using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IesaNews.Models;
using IesaNews.Repository;

namespace IesaNews.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICategoryRepository  categoryRepository;
        private readonly IContactRepository contactRepository;


        public HomeController(ICategoryRepository _categoryRepository, IContactRepository _contactRepository) {
            categoryRepository = _categoryRepository;
            contactRepository = _contactRepository;
        }

        public IActionResult Index()
        {
            List<Category> categories = categoryRepository.getAll();
            if (categories.Count() != 0)
            {
                return View(categories);
            }
            else {
                return View();
            }

        }

        public IActionResult Aviso()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUs contact) {

            contactRepository.save(contact);
            return RedirectToAction("Index");
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


        public IActionResult Team()
        {
            return View();
        }


    }
}
