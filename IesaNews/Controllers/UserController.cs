using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IesaNews.Models;
using IesaNews.Repository;
using Microsoft.AspNetCore.Mvc;
using RegistroLogin.Filters;

namespace IesaNews.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository _userRepository) {
            userRepository = _userRepository;
        }

        [AuthorizeUsers]
        public IActionResult List()
        {
            List<User> users = userRepository.getAll();

            return View(users);
        }


        [AuthorizeUsers]
        public IActionResult Delete(int id)
        {
            userRepository.delete(id);
            return RedirectToAction("list");
        }



        [AuthorizeUsers]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User user = userRepository.getById(id);
            return View(user);
        }


        [AuthorizeUsers]
        [HttpPost]
        public IActionResult Edit(User user)
        {
            int id = user.Id;
           

            return RedirectToAction("list");

        }
    }

}
