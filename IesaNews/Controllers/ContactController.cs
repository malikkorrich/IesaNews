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
    public class ContactController : Controller
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository _contactRepository) {
            contactRepository = _contactRepository;
        }

        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult List()
        {
            List<ContactUs> contacts = contactRepository.getAll();
            return View(contacts);
        }

        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult delete(ContactUs contact)
        {
            contactRepository.delete(contact.Id);
            return RedirectToAction("List");
        }
    }
}