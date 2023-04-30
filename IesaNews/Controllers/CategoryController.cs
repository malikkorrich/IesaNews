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
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository _categoryRepository) {
            categoryRepository = _categoryRepository;
                }


        [AuthorizeUsers]
        public IActionResult List()
        {
            List<Category> categories = categoryRepository.getAll();
            return View(categories);
        }


        [AuthorizeUsers]
        public IActionResult Edit(int id)
        {
            Category category = categoryRepository.getById(id);
   
            return View(category);

        }

        [AuthorizeUsers]

        public IActionResult Add()
        {
            return View();
        }



        [AuthorizeUsers]
        [HttpPost]
        public IActionResult Add(Category category)
        {
            categoryRepository.add(category);
            return RedirectToAction("List");
        }



        [AuthorizeUsers]
        public IActionResult Delete(int id)
        {
            categoryRepository.delete(categoryRepository.getById(id));
            return RedirectToAction("List");
        }
    }
}