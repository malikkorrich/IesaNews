using IesaNews.Context;
using IesaNews.Models;
using IesaNews.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IesaNews.Services
{
    public class CategoryService : ICategoryRepository
    {
        private readonly NewsContext newsContext;


        public CategoryService(NewsContext _newsContext) {
            newsContext = _newsContext;
        }

        public void add(Category category)
        {
            newsContext.categories.Add(category);
            newsContext.SaveChanges();
        }

        public void delete(Category category)
        {
            newsContext.categories.Remove(category);
            newsContext.SaveChanges();
        }

        public void edit(Category category)
        {
            newsContext.categories.Add(category);
            newsContext.SaveChanges();
        }

        public List<Category> getAll()
        { 
                List<Category> categories = (from categoryObj in newsContext.categories select categoryObj).ToList();
                return categories;
         
            
           
        }

        public Category getById(int id)
        {
            Category category = (from categoryObj in newsContext.categories where categoryObj.Id == id select categoryObj).FirstOrDefault();
            return category;
        }
    }
}
