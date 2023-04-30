using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IesaNews.Repository;
using Microsoft.AspNetCore.Mvc;
using RegistroLogin.Filters;

namespace IesaNews.Controllers
{
    public class StaticController : Controller
    {
        private readonly IStaticRepository staticRepository;

       public StaticController(IStaticRepository _staticRepository) {
            staticRepository = _staticRepository;
        }

       [AuthorizeUsers]
        public IActionResult Index()
        {
            int totalArticles = staticRepository.getTotalArticles();
            ViewData["articles"] = totalArticles;

            int totalUsers = staticRepository.getTotalUsers();
            ViewData["users"] = totalUsers;

            int totalContacts = staticRepository.getTotalContact();
            ViewData["contacts"] = totalContacts;

            return View();
        }
    }
}