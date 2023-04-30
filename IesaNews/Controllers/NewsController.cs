using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IesaNews.Models;
using IesaNews.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RegistroLogin.Filters;
using System.Security.Claims;

namespace IesaNews.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository inewsRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUserRepository userRepository;

        public NewsController(INewsRepository _inewsRepository, ICategoryRepository _categoryRepository,IUserRepository _userRepository) {
            inewsRepository = _inewsRepository;
            categoryRepository = _categoryRepository;
            userRepository = _userRepository;
        }



        public IActionResult Index(int id)
        {
            List<News> news = inewsRepository.getByCategory(id);
            if (news.Count() != 0)
            {
                return View(news);
            }
            else {
                return View();
            }

            
        }

        public IActionResult List()
        {
            //Get Users
            List<User> users = userRepository.getAll();
            ViewData["users"] = users;


            List<News> news = inewsRepository.getAll();
            if (news.Count() != 0)
            {
                return View(news);
            }
            else
            {
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            News news = inewsRepository.getById(id);
            return View(news);
        }



        [HttpGet]
        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult Create()
        {
            List<Category> categories = categoryRepository.getAll();

            //Obtener los claims "UserId"
            List<Claim> claimList = User.Identities.First().Claims.ToList();
            string id = claimList?.FirstOrDefault(x => x.Type.Equals("IdUsuario", StringComparison.OrdinalIgnoreCase))?.Value;
        
            //Get news by UserID

            ViewData["UsuarioId"] = id;

            return View(categories);
        }

        [AuthorizeUsers]
        public IActionResult Create(int id)
        {

            return RedirectToAction("edit", "news");
        }

        [AuthorizeUsers]
        [HttpPost]
        public IActionResult Create(News news)
        {
            inewsRepository.add(news);
            return RedirectToAction("edit","news");
        }

        [AuthorizeUsers]
        public IActionResult Delete(int id)
        {
            inewsRepository.delete(id);
            return RedirectToAction("edit", "news");

        }

        [AuthorizeUsers]
        public IActionResult Edit()
        {
            //Obtener los claims "UserId"
            List<Claim> claimList = User.Identities.First().Claims.ToList();
            string id = claimList?.FirstOrDefault(x => x.Type.Equals("IdUsuario", StringComparison.OrdinalIgnoreCase))?.Value;
            int usuarioId = int.Parse(id);
            //Get news by UserID
            List<News> news = inewsRepository.getByUser(usuarioId);

            //Get Categoria
            
            if (news.Count() != 0)
            {
                return View(news);
            }
            else
            {
                return View(news);
            }

            

        }

        [AuthorizeUsers]
        public IActionResult Modify(int id)
        {
            News news = inewsRepository.getById(id);
            List<Category> categories = categoryRepository.getAll();

            TempData["categories"] = categories;

            TempData["id"] = id;

            return View(news);

        }


        [AuthorizeUsers]
        [HttpPost]
        public IActionResult Modify(News news)
        {
            int id = news.Id;
            inewsRepository.edit(news,id);

             return RedirectToAction("edit", "news");

        }
    }
}